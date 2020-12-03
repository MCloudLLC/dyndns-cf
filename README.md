# MCloud LLC - Dynamic DNS using Cloudflare

This project will allow you to update a Cloudflare DNS entry. This could be used as a cronjob or scheduled task to update your IP address if you are in a dynamic IP address environment.

## Configuring the appsettings.json

You will need the following info: 

```json
{
    "CF_API":"https://api.cloudflare.com/client/v4/zones/",
    "CF_API_KEY":"YOUR API KEY",
    "CF_ZONE_ID":"YOUR ZONE ID",
    "CF_DNS_ID":"YOUR DNS RECORD ID",
    "CF_DNS_NAME":"YOUR DNS HOSTNAME",
    "CF_DNS_TYPE":"A",
    "GET_IP_ENDPOINT":"YOUR IP ECHO SERVICE"
}
```
| Settings | Description |
|-----|-----|
| CF_API | The Cloudflare API endpoint. |
| CF_ZONE_ID | The domain Zone ID. You can get this from your Cloudflare Dashboard for your Domain. |
| CF_DNS_ID | The domain's uniquie ID. This can be found by following this [link](https://api.cloudflare.com/#dns-records-for-a-zone-properties).|
| CF_DNS_NAME | The domain name being updated |
| CF_DNS_TYPE | Typically an "A" record. However could be any supported DNS type. |
| GET_IP_ENDPOINT | The endpoint where you could pull your public IP address. This can be done in PHP by doing the following: `<?php echo $_SERVER['REMOTE_ADDR']; ?>` |

## Example appsettings.json

```json
{
    "CF_API":"https://api.cloudflare.com/client/v4/zones/",
    "CF_API_KEY":"xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
    "CF_ZONE_ID":"xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
    "CF_DNS_ID":"xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
    "CF_DNS_NAME":"my-domain-to-change.example.com",
    "CF_DNS_TYPE":"A",
    "GET_IP_ENDPOINT":"https://myechoendpoint.domain.com/"
}
```