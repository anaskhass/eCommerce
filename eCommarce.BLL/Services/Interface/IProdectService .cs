using System;
using Azure.Core;
using eCommarce.DAL.DTO.Requests;
using eCommarce.DAL.DTO.Responses;
using eCommarce.DAL.Models;

namespace eCommarce.BLL.Services.Interface
{
	public interface IProdectService : IGenericServic<ProdectRequest, ProdectResponse, Prodect>
    {
        Task<int>  CreateFile(ProdectRequest request);
    }
}

