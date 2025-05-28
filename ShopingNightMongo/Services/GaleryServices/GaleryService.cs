using AutoMapper;
using MongoDB.Driver;
using ShopingNightMongo.Entities;
using ShopingNightMongo.Dtos.GaleryDtos;
using ShopingNightMongo.Settings;

namespace ShopingNightMongo.Services.GaleryServices
{
    public class GaleryService : IGaleryService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Galery> _galeryCollection;
        public GaleryService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database= client.GetDatabase(_databaseSettings.DatabaseName);
            _galeryCollection = database.GetCollection<Galery>(_databaseSettings.GaleryCollectionName);
            _mapper = mapper;
            
        }

        public async Task CreateGaleryAsync(CreateGaleryDto createGaleryDto)
        {
            var value = _mapper.Map<Galery>(createGaleryDto);
            await _galeryCollection.InsertOneAsync(value);
        }

        public async Task DeleteGaleryAsync(string galeryId)
        {
            await _galeryCollection.DeleteOneAsync(x => x.GaleryId == galeryId);
        }

        public async Task<List<ResultGaleryDto>> GetAllGaleryAsync()
        {
            var values= await _galeryCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultGaleryDto>>(values);
        }

        public async Task<GetGaleryDto> GetGaleryByIdAsync(string galeryId)
        {
            var value = await _galeryCollection.Find(x => x.GaleryId == galeryId).FirstOrDefaultAsync();
            return _mapper.Map<GetGaleryDto>(value);
        }

        public async Task UpdateGaleryAsync(UpdateGaleryDto updateGaleryDto)
        {
            var value = _mapper.Map<Galery>(updateGaleryDto);
            await _galeryCollection.FindOneAndReplaceAsync(x => x.GaleryId == updateGaleryDto.GaleryId, value);
        }
    }
}
