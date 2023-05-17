using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISegmentService
    {
        IDataResult<List<Segment>> GetAll();
        IDataResult<List<Segment>> GetById(int segmentId);
        IResult Add(Segment segment);
        IResult Update(Segment segment);
        IResult Delete(Segment segment);
    }
}
