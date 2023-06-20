using System.Linq.Expressions;
using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Wheelo.Bll.Models.Dtos;
using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;
using Intotech.Wheelo.Bll.Persistence;
using Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Logic.DtoLogics;

public class VtripsparticipantDtoLogic : DtoLogicBase< VtripsparticipantModelDto , Vtripsparticipant , VtripsparticipantLogic , VtripsparticipantDto >
{
    public VtripsparticipantDtoLogic(int id) 
        : base(new VtripsparticipantLogic(), m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Vtripsparticipant = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Vtripsparticipant> GetDtoModelField(VtripsparticipantDto dto)
    {
       return dto.Vtripsparticipant;
    }

    protected override VtripsparticipantDto FillEntity(VtripsparticipantDto dto, DtoBase<Vtripsparticipant> field)
    {
        dto.Vtripsparticipant = (VtripsparticipantModelDto)field;

        return dto;
    }
}
