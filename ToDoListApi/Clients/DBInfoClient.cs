using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using ToDoListApi.Models.DBModel;
using ToDoListApi.Extensions;
namespace ToDoListApi.Clients
{
    public class DBInfoClient
    {
        public string _tableName;
        private readonly IAmazonDynamoDB _amazonDynamoDB;
        public DBInfoClient(IAmazonDynamoDB amazonDynamoDB)
        {
            _amazonDynamoDB = amazonDynamoDB;
            _tableName = "InfoAboutCityAndCountry";
        }
        public async Task<bool> PostInfo(InfoModel infoModel)
        {
            var request = new PutItemRequest
            {
                TableName = _tableName,
                Item = new Dictionary<string, AttributeValue>()
                {
                    
                    {"UID", new AttributeValue{S = infoModel.UID } },
                    {"Country", new AttributeValue {S = infoModel.Country} },
                    {"City", new AttributeValue {S = infoModel.City} }
                },
            };
            var response = await _amazonDynamoDB.PutItemAsync(request);
            return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
        }
        public async Task<bool> DeleteInfo(InfoModel infoModel)
        {
            var request = new DeleteItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>()
                {
                    {"UID", new AttributeValue{S = infoModel.UID } }
                    
                }
            };
            var response = await _amazonDynamoDB.DeleteItemAsync(request);
            return (response.HttpStatusCode == System.Net.HttpStatusCode.OK);
        }
        public async Task<InfoModel> GetInfo(string UID)
        {
            var info = new GetItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    {"UID", new AttributeValue{S = UID} }
                }
            };
            InfoModel result;
            var response = _amazonDynamoDB.GetItemAsync(info).Result;
            if (response == null)
            {
                return null;
            }
            else result = response.Item.ToClass<InfoModel>();
            return result;


        }
    }
}
