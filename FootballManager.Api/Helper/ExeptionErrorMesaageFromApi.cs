using FootballManager.Bll.Concrete;
using FootballManager.Core.Entities;
using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using static FootballManager.Bll.Concrete.Validation.ValidationIsNullOrWhitespace;
using static FootballManager.Bll.Helpers.ToPasswordRepository;
namespace FootballManager.Api.Helper
{
    public static class ExeptionErrorMesaageFromApi
    {
        public static string ListAllErrorMessages(ModelStateDictionary modelState)
        {
            string errormasages = "";
            modelState.SelectMany(x => x.Value.Errors).ToList().ForEach(x =>
            {
                errormasages += $"{x.ErrorMessage}\n";
            });
            errormasages.Remove(errormasages.Length - 1, 1);
            return errormasages;
        }
        /// <summary>
        /// status= true : Add
        /// status= false : Update
        /// </summary>
        public static EntityHttpResponse ControlBeforeAddorUpdate<TEntity>(TEntity entity, ModelStateDictionary modelState, HttpRequestMessage request, EntityManager<TEntity> manager, bool status) where TEntity : EntityBase, new()
        {
            string erorrs = ValidationIsNullOrEmpty(entity);
            if (modelState.IsValid && string.IsNullOrWhiteSpace(erorrs))
            {
                try
                {
                    if (status)
                    {
                        //if (entity is User user)
                        //    user.Password = PasswordCryptographyCombine(user.Password);
                        manager.Add(entity);
                    }
                    else
                        manager.Update(entity);
                    manager.Save();
                    return new EntityHttpResponse(HttpStatusCode.OK, "Gennemført", true);
                }
                catch (Exception ex)
                {
                    erorrs += ex.Message;
                    return new EntityHttpResponse(HttpStatusCode.BadRequest, erorrs, false);
                }
            }
            else
            {
                erorrs += "\n" + ListAllErrorMessages(modelState);
                return new EntityHttpResponse(HttpStatusCode.NotFound, erorrs, false);
            }
        }
    }
}
