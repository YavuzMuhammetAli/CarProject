using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SegmentManager : ISegmentService
    {
        ISegmentDal _segmentDal;
        public SegmentManager(ISegmentDal segmentDal)
        {
            _segmentDal = segmentDal;
        }

        public IResult Add(Segment segment)
        {
            _segmentDal.Add(segment);
            return new SuccessResult(Messages.SegmentAdded);
        }

        public IResult Update(Segment segment)
        {
            _segmentDal.Update(segment);
            return new SuccessResult(Messages.SegmentUpdated);
        }

        public IResult Delete(Segment segment)
        {
            _segmentDal.Delete(segment);
            return new SuccessResult(Messages.SegmentDeleted);
        }

        public IDataResult<List<Segment>> GetAll()
        {
            return new SuccessDataResult<List<Segment>>(_segmentDal.GetAll(),Messages.SegmentAllListed);
        }

        public IDataResult<List<Segment>> GetById(int segmentId)
        {
            return new SuccessDataResult<List<Segment>>(_segmentDal.GetAll(s => s.Id == segmentId), Messages.SegmentByIdListed);
        }       
    }
}
