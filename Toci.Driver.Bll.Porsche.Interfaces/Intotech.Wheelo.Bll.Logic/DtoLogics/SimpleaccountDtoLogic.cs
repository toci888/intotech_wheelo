usignsad

asdasdasd

public class SimpleaccountDtoLogic : DtoLogicBase<SimpleaccountModelDto, Simpleaccount, ISimpleaccountLogic, SimpleaccountDto, List<Simpleaccount>, List<SimpleaccountModelDto>>
{
    public SimpleaccountDtoLogic(ISimpleaccountLogic simpleaccountlogic) 
        : base(simpleaccountlogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Simpleaccount = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Simpleaccount,SimpleaccountDto> GetDtoModelField(SimpleaccountDto dto)
    {
       return dto.Simpleaccount;
    }

    protected override SimpleaccountDto FillEntity(SimpleaccountDto dto, DtoBase<Simpleaccount> field)
    {
        dto.Simpleaccount = (SimpleaccountModelDto)field;

        return dto;
    }
}
