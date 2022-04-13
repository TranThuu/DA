﻿using AutoMapper;
using FlarumWebApp.Repository.Infrastructures;
using FlarumWebApp.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlarumWebApp.Services.Services
{
    public class SavedPostService:ISavedPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SavedPostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


    }
}