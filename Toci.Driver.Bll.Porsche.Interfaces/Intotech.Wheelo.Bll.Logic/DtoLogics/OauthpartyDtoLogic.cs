usignsad

asdasdasd

public class OauthpartyDtoLogic : DtoLogicBase<OauthpartyModelDto, Oauthparty, IOauthpartyLogic, OauthpartyDto, List<Oauthparty>, List<OauthpartyModelDto>>
{
    public OauthpartyDtoLogic(IOauthpartyLogic oauthpartylogic) 
        : base(oauthpartylogic, m => m.Id == id, 
            (aDto, aModelDto) => { 
                aDto.Oauthparty = aModelDto;
                return aDto;
            })
    {
    }

    protected override DtoBase<Oauthparty,OauthpartyDto> GetDtoModelField(OauthpartyDto dto)
    {
       return dto.Oauthparty;
    }

    protected override OauthpartyDto FillEntity(OauthpartyDto dto, DtoBase<Oauthparty> field)
    {
        dto.Oauthparty = (OauthpartyModelDto)field;

        return dto;
    }
}
