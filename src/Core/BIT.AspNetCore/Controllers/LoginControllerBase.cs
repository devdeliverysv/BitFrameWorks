﻿using BIT.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BIT.AspNetCore.Controllers
{
    //public abstract class LoginControllerBase : BaseController
    //{

    //    private const string HeaderId = "HeaderId";
    //    private IConfigResolver<IDataStore> resolver;
    //    private IObjectSerializationHelper iObjectSerializationHelper;
    //    private IStringSerializationHelper iStringSerializationHelper;


    //    public IStringSerializationHelper StringSerializationHelper { get => iStringSerializationHelper; protected set => iStringSerializationHelper = value; }
    //    public IObjectSerializationHelper ObjectSerializationHelper { get => iObjectSerializationHelper; protected set => iObjectSerializationHelper = value; }
    //    public IConfigResolver<IDataStore> Resolver { get => resolver; protected set => resolver = value; }

    //    public LoginControllerBase(IConfigResolver<IDataStore> DataStoreResolver, IObjectSerializationHelper objectSerializationHelper, IStringSerializationHelper stringSerializationHelper)
    //    {
    //        Resolver = DataStoreResolver;
    //        ObjectSerializationHelper = objectSerializationHelper;
    //        StringSerializationHelper = stringSerializationHelper;
    //    }
    //    protected virtual ApiAuthenticationResult Authenticate(LoginParameters LoginParameters)
    //    {

    //        throw new NotImplementedException();
    //    }

    //    protected virtual LoginResult BuildLoginResult(string Key, string Issuer, ApiAuthenticationResult AuthenticationResult)
    //    {
    //        LoginResult LoginResult = new LoginResult();
    //        LoginResult.Authenticated = AuthenticationResult.Authenticated;
    //        LoginResult.Username = AuthenticationResult.Username;
    //        LoginResult.UserId = AuthenticationResult.UserId;
    //        LoginResult.LastError = AuthenticationResult.LastError;

    //        List<Claim> Claims = new List<Claim>();

    //        if (AuthenticationResult != null)
    //        {
    //            foreach (KeyValuePair<string, object> Parameter in AuthenticationResult)
    //            {
    //                Claims.Add(new Claim(Parameter.Key, Parameter.Value?.ToString()));
    //            }
    //        }
    //        if (AuthenticationResult.Authenticated)
    //        {
    //            Claims.Add(new Claim(JwtRegisteredClaimNames.Iat, JwtHelper.ConvertToUnixTime(DateTime.Now).ToString()));
    //            Claims.Add(new Claim(JwtRegisteredClaimNames.Iss, Issuer));
    //            JwtPayload InitialPayload = new JwtPayload(Claims);
    //            LoginResult.Token = JwtHelper.GenerateToken(Key, InitialPayload);
    //        }
    //        else
    //        {
    //            LoginResult.Token = string.Empty;
    //        }

    //        return LoginResult;

    //    }
    //    [HttpPost]
    //    [Route("[action]")]
    //    public virtual async Task<IActionResult> Login()
    //    {


    //        byte[] Bytes = null;
    //        try
    //        {
    //            Bytes = await Request.GetRawBodyBytesAsync();

    //            var LoginParametersJsonString = this.ObjectSerializationHelper.GetObjectsFromByteArray<string>(Bytes);

    //            var LoginParameters = JsonConvert.DeserializeObject<LoginParameters>(LoginParametersJsonString);
    //            string dataStoreId = GetHeader(HeaderId);


    //            IConfigurationRoot Configuration = GetConfigurationBuilder().Build();

    //            var Key = Configuration["Token:Key"];
    //            var Issuer = Configuration["Token:Issuer"];

    //            var AuthenticationResult = Authenticate(LoginParameters);
    //            var data = BuildLoginResult(Key, Issuer, AuthenticationResult);

    //            return base.Ok(data);

    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest(ex);
    //        }


    //    }

    //}
}