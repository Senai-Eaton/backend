using System;
using System.Text;
using eaton.agir.domain.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace eaton.agir.webApi.util
{
    public class Hashcode
    {
        public static   string getHash(UsuarioDomain usuario){
        string sal="protegendoseucodigo";
        var salt= Encoding.ASCII.GetBytes(sal);
        string hash= Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: usuario.Senha,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount:10000,
            numBytesRequested:256/8

        ));
return hash;

        }
        
    }
}