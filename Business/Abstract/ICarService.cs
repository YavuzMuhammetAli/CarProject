﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetail();
        IDataResult<List<CarFullDetailDto>> GetCarFullDetail();
        IResult Add(Car car);
        IResult Update(Car car);
    }
}
