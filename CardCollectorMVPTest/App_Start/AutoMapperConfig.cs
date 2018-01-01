using AutoMapper;
using CardCollectorMVPTest;
using CardCollectorStandard.Domain.Models;

public class AutoMapperConfig
{
    public static void Configure()
    {
        Mapper.Initialize(config =>
        {
            //CardCollectorMVPTest
            config.AddProfile<MVPTestAutoMapperProfile>();

            //CardCollectorStandard.Domain
            config.AddProfile<CardAutoMapperProfile>();
        });
    }
}
