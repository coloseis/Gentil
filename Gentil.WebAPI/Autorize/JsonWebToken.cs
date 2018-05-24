using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.ServiceModel.Security.Tokens;
using System.Threading;
using System.Web;
using Gentil.Service.Models;

namespace Gentil.WebAPI.Autorize
{
    public class JsonWebToken
    {
        private const string clave = "Gentil.jsonWebToken";
        public string Encode(UserDTO usuario)
        {
            var now = DateTime.UtcNow;

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor();

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, usuario.Name, ClaimValueTypes.String));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, usuario.ID.ToString(), ClaimValueTypes.Integer));
            claims.Add(new Claim(ClaimTypes.Role, usuario.RoleID.ToString(), ClaimValueTypes.Integer));

            tokenDescriptor.Subject = new ClaimsIdentity(claims);

            tokenDescriptor.TokenIssuerName = "self";
            tokenDescriptor.AppliesToAddress = ConfigurationManager.AppSettings["SecurityTokenAddress"];

            tokenDescriptor.Lifetime = new Lifetime(now, now.AddHours(1));
            tokenDescriptor.SigningCredentials = new SigningCredentials(new InMemorySymmetricSecurityKey(AutorizeHelper.GetBytes(clave)), "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256", "http://www.w3.org/2001/04/xmlenc#sha256");

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        

        public void DecodeToPrincipal(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters();
            tokenValidationParameters.ValidIssuer = "self";
            tokenValidationParameters.ValidAudience = ConfigurationManager.AppSettings["SecurityTokenAddress"];
            tokenValidationParameters.IssuerSigningToken = new BinarySecretSecurityToken(AutorizeHelper.GetBytes(clave));

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;
            var tokenIdentity = tokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken).Identities.First();

            var usuarioId = int.Parse(tokenIdentity.Claims.Single(c => c.Type.Contains("nameidentifier")).Value);
            var userName = tokenIdentity.Name;

            GenericIdentity identity = new GenericIdentity(tokenIdentity.Name);
            var roles = tokenIdentity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToArray();

            var principal = new GentilPrincipal(usuarioId, userName, identity, roles);
            //AutorizeHelper.Principal = principal;
            Thread.CurrentPrincipal = principal;
            HttpContext.Current.User = principal;
        }
    }
}