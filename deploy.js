const {deployNodeJS} = require("@azure/api-management-custom-widgets-tools")

const serviceInformation = {
	"resourceId": "subscriptions/{subscription}/resourceGroups/{resourceGroup}/providers/Microsoft.ApiManagement/service/{apimInstanceName}",
	"managementApiEndpoint": "https://management.azure.com",
	"apiVersion": "2022-08-01"
}
const name = "my-apim-widget"
const fallbackConfigPath = "./static/config.msapim.json"

deployNodeJS(serviceInformation, name, fallbackConfigPath)
