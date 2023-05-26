const {deployNodeJS} = require("@azure/api-management-custom-widgets-tools")

const serviceInformation = {
	"resourceId": "subscriptions/700d9ddb-edfa-43c7-9028-7936c4676a7a/resourceGroups/stv1/providers/Microsoft.ApiManagement/service/stv1-test",
	"managementApiEndpoint": "https://management.azure.com",
	"apiVersion": "2022-08-01"
}
const name = "my-apim-widget"
const fallbackConfigPath = "./static/config.msapim.json"

deployNodeJS(serviceInformation, name, fallbackConfigPath)
