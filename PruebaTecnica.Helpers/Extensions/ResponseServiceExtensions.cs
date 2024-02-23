using Newtonsoft.Json;
using PruebaTecnica.Models.Dtos;
using PruebaTecnica.Models.Enums;
using PruebaTecnica.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Helpers.Extensions
{
    public static class ResponseServiceExtensions
    {
        #region Methods Succes

        public async static Task<ResponseServiceDto<T>> GetResultSucces<T>(this ResponseServiceDto<T> responseServiceDto)
        {
            Messages message = await Configuration(ResponseMessages.MESSAGE1);
            responseServiceDto.Code = message.Type;
            responseServiceDto.Message = message.Message;
            return responseServiceDto;
        }

        public async static Task<ResponseServiceDto<T>> GetResultSucces<T>(this ResponseServiceDto<T> responseServiceDto, T param)
        {
            Messages message = await Configuration(ResponseMessages.MESSAGE1);
            responseServiceDto.Code = message.Type;
            responseServiceDto.Message = message.Message;
            responseServiceDto.Result = param;
            return responseServiceDto;
        }

        #endregion

        #region Methods error
        public async static Task<ResponseServiceDto<T>> GetResultError<T>(this ResponseServiceDto<T> responseServiceDto)
        {
            Messages message = await Configuration(ResponseMessages.MESSAGE2);
            responseServiceDto.Code = message.Type;
            responseServiceDto.Message = message.Message;
            return responseServiceDto;
        }

        public async static Task<ResponseServiceDto<T>> GetResultError<T>(this ResponseServiceDto<T> responseServiceDto, T param)
        {
            Messages message = await Configuration(ResponseMessages.MESSAGE2);
            responseServiceDto.Code = message.Type;
            responseServiceDto.Message = message.Message;
            responseServiceDto.Result = param;
            return responseServiceDto;
        }
        #endregion

        #region Message dynamic

        public async static Task<ResponseServiceDto<T>> GetResult<T, TMessage>(this ResponseServiceDto<T> responseServiceDto, TMessage responseMessages)
        {
            Messages message = await Configuration(responseMessages);

            responseServiceDto.Code = message.Type;
            responseServiceDto.Message = message.Message;

            return responseServiceDto;
        }

        public async static Task<ResponseServiceDto<T>> GetResult<T, TMessage>(this ResponseServiceDto<T> responseServiceDto, TMessage responseMessages, T param)
        {
            Messages message = await Configuration(responseMessages);
            responseServiceDto.Code = message.Type;
            responseServiceDto.Message = message.Message;
            responseServiceDto.Result = param;
            return responseServiceDto;
        }

        #endregion

        private async static Task<Messages> Configuration<TMessage>(TMessage responseMessagesEnum)
        {
            string runDir = Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location) + "\\Message.json";
            string Text = await File.ReadAllTextAsync(runDir);
            Messages message = JsonConvert.DeserializeObject<List<Messages>>(Text)!.FirstOrDefault(x => x.Code == Convert.ToInt32(responseMessagesEnum))!;
            return message;

        }
    }
}
