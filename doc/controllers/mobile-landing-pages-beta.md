# Mobile Landing Pages Beta

The mobile landing pages (MLP) API provides the facilities to create mobile landing pages and sends them to recipients. This API is currently in beta.

## Concepts

The approach to creating mobile landing pages involves creating a _Campaign_ and sending them to one or more _Recipients_.  A campaign consists of the baseline configuration of a mobile landing page and message that will be generated and sent to each recipient.

## Parameters

Campaign and Recipients can contain parameters.  These parameters are used to customise the generated landing page and the message that is to be sent to each user.  Campaign and Recipient parameters are merged to form a complete set when processing a recipient.

When resolving parameters sets, Recipient parameters override Campaign parameters with the same name.

Parameter names used within the template have an associated type, which will be validated when creating the Campaign or sending it to Recipients.  You are free to define additional parameters for your own uses, such as when specifying the message.

The SMS message that is to be sent to each user is defined at the Campaign level.

The message itself can consist of parameter references surrounded in `${...}`, for example:

`Hello ${firstName} ${lastName}, this is your message.`

## Sending Mobile Landing Pages

From end to end, sending a Mobile Landing Pages involves the following steps:

### Step 1: Create a campaign

Choose a template from the template catalogue, and work out what you are going to specify for the required parameters for that template. You will then use the `Create new campaign` endpoint to create the campaign. The following example
specifies the desired parameters for the template_id and sets up a message template:

```
{
    "template_id": "ac895f01-3149-4bf8-a8fe-01d3b8a9ba97",
    "parameters": {
      "pageTitle": "The page title",
      "pageText": "The body text",
      "imageUrl": "https://example.com/image.jpg",
      "secondaryImageUrl": "https://www.example.com/optional_secondary_image.jpg",
      "buttonLink": "https://example.com/",
      "buttonText": "Call to Action Button Text",
      "secondaryButtonLink": "https://example.com/optional_secondary_button",
      "secondaryButtonText": "Secondary Call to Action Button"
    },
    "message": {
      "content": "Hello ${firstName} ${lastName}, this is the SMS message body",
      "metadata": {
        "key": "value"
      }
    }
}
```

Inside the message content the `{}` curly braces indicate template placeholders. These are the names of the parameters you will need to specify for the message when you send to your recipients.

### Step 2: Send to recipients

Using the `Send campaign to recipients` endpoint, you can specify the id of your campaign in the path and a array of recipients as the payload. Each recipient will include an E.164 formatted
(international) phone number, an optional scheduled time, and values of any recipient scoped template parameters you may have created. In the following example the recipients have been scoped with the template parameters above:

```
{
  "recipients": [
    {
      "number": "+6140000000",
      "parameters": { "firstName":"Joe", "lastName","Bloe" }
    },
    {
      "number": "+6141111111",
      "parameters": { "firstName":"Jane", "lastName","Doe" }
    }
  ]
}
```

## Landing Page Store

The Landing Page Store is used by the Hub portal to store landing page templates that have been configured using the visual interface. This means that you can
optionally use this data store to programatically send landing pages that have been designed and configured in the hub.

If you have made a landing page in the hub, use the `Get landing pages` endpoint to find the landing pages you have made, along with the template and parameters that have been configured.
You will then need to copy those template and parameters into a campaign.

## Template Parameters

Each template will have different required parameters, shown in the Templates section. The following is a description of the requirements of each parameter when included in a template.

| Parameter | Required | Tyep|Description |
|------------------|-------------|-----------|-----------|
| imageBackgroundUrl | Optional - depends on MLP template. |image| Width: 750 pixels, height: 1624 pixels, size: less than 300 kB, type: png, gif, or jpg|
| barcodeValue | Optional - depends on MLP template. |text| Alphanumeric string. We will use CODE-128 format 1-D barcode. |
| barcodeDisplayValue | Optional - defaults to true. Otherwise, use false |text| Indicates whether the barcode value is shown below the barcode image|
| barcodeHeight| Optional| text||
| barcodeMargin| Optional| text||
| barcodeWidth| Optional| text||
| barcodeLineColor|Optional - each template has it's own default value| text|  Indicate the color of bar code. Use a color name(eg. 'red', 'green'), or a hex value(eg. '#F0F8FF') |
| pageText | |html| For personalisation, use the following format: “Hi ${firstName}, thanks for visiting…”|
| pageTextColor|Optional - each template has it's own default value| text|  Indicate the color of page text. Use a color name(eg. 'red', 'green'), or a hex value(eg. '#F0F8FF') |
| imageHeaderUrl | Optional - depends on MLP template |image| Width: 750 pixels, height: 375 pixels, size: less than 300 kB, type: png, gif, or jpg.|
| headline | |text| For personalisation, use the following format: “Hi ${firstName}, thanks for visiting…”. Specifications: 60 characters or less recommended|
| headlineColor|Optional - each template has it's own default value| text|  Indicate the color of headline. Use a color name(eg. 'red', 'green'), or a hex value(eg. '#F0F8FF') |
| pageTitle | |text| HTML page title shown on browser tab. Specifications: 60 characters or less recommended.|
| imageLogoUrl |Optional |image| Specifications: width: 300 pixels, height: 120 pixels, size: less than 300 kB, type: png, gif, or jpg|
| logoLink | Optional|url| For personalisation, use the following format: “https://example.com/?cid=${customerId}”|
| primaryButtonLink | |url| For personalisation, use the following format: “https://example.com/?cid=${customerId}”|
| primaryButtonText | |text| For personalisation, use the following format: “${firstName}, shop now”. Specifications: 36 characters or less recommended |
| primaryButtonTextColor|Optional - each template has it's own default value| text|  Indicate the color of primary button text. Use a color name(eg. 'red', 'green'), or a hex value(eg. '#F0F8FF') |
| primaryButtonBackgroundColor|Optional - each template has it's own default value| text|  Indicate the background color of primary button. Use a color name(eg. 'red', 'green'), or a hex value(eg. '#F0F8FF') |
| secondaryButtonLink | Optional - depends on MLP template |url| For personalisation, use the following format: “https://example.com/?cid=${customerId}”|
| secondaryButtonText | Optional - depends on MLP template |text| For personalisation, use the following format: “Hi ${firstName}, thanks for visiting…”. Specifications: 36 characters or less recommended |
| secondaryButtonTextColor|Optional - each template has it's own default value| text|  Indicate the color of the secondary button text. Use a color name(eg. 'red', 'green'), or a hex value(eg. '#F0F8FF') |
| secondaryButtonBackgroundColor|Optional - each template has it's own default value| text|  Indicate the background color of secondary button. Use a color name(eg. 'red', 'green'), or a hex value(eg. '#F0F8FF') |
| fontFamilyURL1 | Optional - each template has it's own default value|url| Indicate the url of font family, those font family can be used in other property(eg. `headlineFontFamily`)|
| fontFamilyURL2 | Optional - each template has it's own default value|url| Indicate the url of font family, those font family can be used in other property(eg. `headlineFontFamily`)|
| fontFamilyURL3 | Optional - each template has it's own default value|url| Indicate the url of font family, those font family can be used in other property(eg. `headlineFontFamily`)|
| pageTextFontFamily | |text| Specify the font family of page text |
| headlineFontFamily | |text| Specify the font family of headline text |
| buttonFontFamily | |text| Specify the font family of button text |

## Template Catalogue

| Name and preview | Template ID |
|-------------------|-------------|
| ![](Https://developers.messagemedia.com/wp-content/templates/Template1.png) | 7614456e-844f-4d83-bdfe-20c17ce0f97c |
| ![](Https://developers.messagemedia.com/wp-content/templates/Template2.png) | f56b5806-f732-4693-b87a-90b66a7d7bfc |
|![](Https://developers.messagemedia.com/wp-content/templates/template3.png) | c9d7ce1d-20c4-4228-9ba1-6da2a3b4e5e0 |

```csharp
MobileLandingPagesBetaController mobileLandingPagesBetaController = client.MobileLandingPagesBetaController;
```

## Class Name

`MobileLandingPagesBetaController`

## Methods

* [Create New Campaign](../../doc/controllers/mobile-landing-pages-beta.md#create-new-campaign)
* [Get Campaign](../../doc/controllers/mobile-landing-pages-beta.md#get-campaign)
* [Createa Landing Page](../../doc/controllers/mobile-landing-pages-beta.md#createa-landing-page)
* [Get Landing Pages](../../doc/controllers/mobile-landing-pages-beta.md#get-landing-pages)
* [Deletea Landing Page](../../doc/controllers/mobile-landing-pages-beta.md#deletea-landing-page)
* [Updatea Landing Page](../../doc/controllers/mobile-landing-pages-beta.md#updatea-landing-page)
* [Get Campaign Summary](../../doc/controllers/mobile-landing-pages-beta.md#get-campaign-summary)
* [Get Campaign Events](../../doc/controllers/mobile-landing-pages-beta.md#get-campaign-events)
* [Get Templates Fields Definition](../../doc/controllers/mobile-landing-pages-beta.md#get-templates-fields-definition)
* [Get Templates](../../doc/controllers/mobile-landing-pages-beta.md#get-templates)
* [Send Campaign to Recipients](../../doc/controllers/mobile-landing-pages-beta.md#send-campaign-to-recipients)
* [Export Campaign Events Async](../../doc/controllers/mobile-landing-pages-beta.md#export-campaign-events-async)


# Create New Campaign

Mobile Landing Pages Campaigns belonging to the user.Create a new campaign.

```csharp
CreateNewCampaignAsync(
    Models.BetaSmsplusCampaignsRequest body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.BetaSmsplusCampaignsRequest`](../../doc/models/beta-smsplus-campaigns-request.md) | Body, Optional | - |

## Response Type

[`Task<Models.CreateNewCampaignresponse>`](../../doc/models/create-new-campaignresponse.md)

## Example Usage

```csharp
try
{
    CreateNewCampaignresponse result = await mobileLandingPagesBetaController.CreateNewCampaignAsync(null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "id": "null",
  "template_id": "null",
  "parameters": {
    "title": "This is a title",
    "bodyText": "This is some body text",
    "callToAction": "http://www.example.com/"
  },
  "message": {
    "callback_url": "https://my.url.com",
    "content": "Hello world!",
    "destination_number": "+61491570156",
    "delivery_report": false,
    "format": "SMS",
    "message_expiry_timestamp": "2016-11-03T11:49:02.000+00:00",
    "metadata": {},
    "scheduled": "2016-11-03T11:49:02.000+00:00",
    "source_number": "+61491570156",
    "source_number_type": "INTERNATIONAL",
    "message_id": "d7d9d9fd-478f-40e6-b651-49b7f19878a2",
    "status": "enroute",
    "media": [
      "https://images.pexels.com/photos/1018350/pexels-photo-1018350.jpeg?cs=srgb&dl=architecture-buildings-city-1018350.jpg"
    ],
    "subject": "string"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | - | `ApiException` |
| 402 | - | `ApiException` |


# Get Campaign

A single campaign, identified by a unique identifier.Returns the details of a single campaign.

```csharp
GetCampaignAsync(
    string id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | - |

## Response Type

[`Task<Models.GetCampaignresponse>`](../../doc/models/get-campaignresponse.md)

## Example Usage

```csharp
string id = "id0";

try
{
    GetCampaignresponse result = await mobileLandingPagesBetaController.GetCampaignAsync(id);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "id": "null",
  "template_id": "null",
  "parameters": {
    "title": "This is a title",
    "bodyText": "This is some body text",
    "callToAction": "http://www.example.com/"
  },
  "message": {
    "callback_url": "https://my.url.com",
    "content": "Hello world!",
    "destination_number": "+61491570156",
    "delivery_report": false,
    "format": "SMS",
    "message_expiry_timestamp": "2016-11-03T11:49:02.000+00:00",
    "metadata": {},
    "scheduled": "2016-11-03T11:49:02.000+00:00",
    "source_number": "+61491570156",
    "source_number_type": "INTERNATIONAL",
    "message_id": "d7d9d9fd-478f-40e6-b651-49b7f19878a2",
    "status": "enroute",
    "media": [
      "https://images.pexels.com/photos/1018350/pexels-photo-1018350.jpeg?cs=srgb&dl=architecture-buildings-city-1018350.jpg"
    ],
    "subject": "string"
  }
}
```


# Createa Landing Page

The Landing Page datastore makes it easier to create Campiangs based on the saved data.Create a Landing Page.

```csharp
CreateaLandingPageAsync(
    Models.BetaSmsplusLandingPagesRequest body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.BetaSmsplusLandingPagesRequest`](../../doc/models/beta-smsplus-landing-pages-request.md) | Body, Optional | - |

## Response Type

[`Task<Models.CreateaLandingPageresponse>`](../../doc/models/createa-landing-pageresponse.md)

## Example Usage

```csharp
try
{
    CreateaLandingPageresponse result = await mobileLandingPagesBetaController.CreateaLandingPageAsync(null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "id": "a94041bb-704b-48fa-ba0b-6f1538fc502f",
  "name": " My Landing Page",
  "template_id": "ac895f01-3149-4bf8-a8fe-01d3b8a9ba97",
  "parameters": {
    "title": "This is a ${title}",
    "bodyText": "This is some ${bodyText}",
    "callToAction": "${ctaUrl}"
  },
  "fields": {
    "title": {
      "type": "TEXT"
    },
    "bodyText": {
      "type": "TEXT"
    },
    "ctaUrl": {
      "type": "URL"
    }
  },
  "created_timestamp": "2019-11-03T11:49:02.807Z",
  "modified_timestamp": "2019-11-03T11:49:02.807Z"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | - | `ApiException` |
| 402 | - | `ApiException` |


# Get Landing Pages

The Landing Page datastore makes it easier to create Campiangs based on the saved data.Returns a paginated list of Landing Pages for your account. `sort_by` and `sort_direction` must both be specified or neither at all (the default sort options are `DESCENDING` `MODIFIED_TIMESTAMP`).

```csharp
GetLandingPagesAsync(
    string pageSize = null,
    string pageToken = null,
    string sortBy = null,
    string sortDirection = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `pageSize` | `string` | Query, Optional | Page size between 5 and 100 (default 20) |
| `pageToken` | `string` | Query, Optional | Token to fetch the next page |
| `sortBy` | `string` | Query, Optional | Can be `CREATED_TIMESTAMP` or `UPDATED_TIMESTAMP` |
| `sortDirection` | `string` | Query, Optional | Can be `ASCENDING` or `DESCENDING` |

## Response Type

`Task<object>`

## Example Usage

```csharp
try
{
    object result = await mobileLandingPagesBetaController.GetLandingPagesAsync(null, null, null, null);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 402 | - | `ApiException` |


# Deletea Landing Page

The Landing Page datastore makes it easier to create Campiangs based on the saved data.Delete a Landing Page.

```csharp
DeleteaLandingPageAsync(
    string id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | - |

## Response Type

`Task`

## Example Usage

```csharp
string id = "id0";

try
{
    await mobileLandingPagesBetaController.DeleteaLandingPageAsync(id);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 402 | - | `ApiException` |


# Updatea Landing Page

The Landing Page datastore makes it easier to create Campiangs based on the saved data.Update a Landing Page.

```csharp
UpdateaLandingPageAsync(
    string id,
    Models.BetaSmsplusLandingPagesRequest1 body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | - |
| `body` | [`Models.BetaSmsplusLandingPagesRequest1`](../../doc/models/beta-smsplus-landing-pages-request-1.md) | Body, Optional | - |

## Response Type

[`Task<Models.UpdateaLandingPageresponse>`](../../doc/models/updatea-landing-pageresponse.md)

## Example Usage

```csharp
string id = "id0";

try
{
    UpdateaLandingPageresponse result = await mobileLandingPagesBetaController.UpdateaLandingPageAsync(id, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "id": "a94041bb-704b-48fa-ba0b-6f1538fc502f",
  "name": " My Landing Page",
  "template_id": "ac895f01-3149-4bf8-a8fe-01d3b8a9ba97",
  "parameters": {
    "pageTitle": "The new page title",
    "pageText": "The new body text",
    "callToAction": "${ctaUrl}"
  },
  "fields": {
    "title": {
      "type": "TEXT"
    },
    "bodyText": {
      "type": "TEXT"
    },
    "ctaUrl": {
      "type": "URL"
    }
  },
  "created_timestamp": "2019-11-03T11:49:02.807Z",
  "modified_timestamp": "2019-11-04T11:49:02.807Z"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | - | `ApiException` |
| 402 | - | `ApiException` |


# Get Campaign Summary

The reporting endpoint provides access to the reporting analytics.

### Events Types

The campaign report consists of a series of events, that were generated by recipients when
interacting with the generated mobile landing page.  The set of events that are currently supported
are as follows:

| Event Type        | Event Source | Description                                    |
|:------------------|:-------------|:-----------------------------------------------|
| `PAGE_OPEN`       | n/a          | The page was opened in a browser.              |
| `BUTTON_CLICKED`  | Button label | One of the Call to Action buttons was clicked. |
| `FORM_SUBMITTED`  | n/a          | A form has been submitted with the captured data stored in the 'data' field. |Returns the breakdown of events and recipients of a particular campaign.

```csharp
GetCampaignSummaryAsync(
    string campaignId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `campaignId` | `string` | Template, Required | The campaign ID |

## Response Type

[`Task<Models.CampaignSummary>`](../../doc/models/campaign-summary.md)

## Example Usage

```csharp
string campaignId = "campaign_id0";

try
{
    CampaignSummary result = await mobileLandingPagesBetaController.GetCampaignSummaryAsync(campaignId);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "total_events": 24,
  "unique_engagements": 9,
  "event_summary": [
    {
      "event": "PAGE_OPEN",
      "total_events": 8,
      "unique_recipients": 6
    },
    {
      "event": "BUTTON_CLICK",
      "source": "OK",
      "total_events": 12,
      "unique_recipients": 8
    },
    {
      "event": "BUTTON_CLICK",
      "source": "Cancel",
      "total_events": 4,
      "unique_recipients": 1
    }
  ]
}
```


# Get Campaign Events

The reporting endpoint provides access to the reporting analytics.

### Events Types

The campaign report consists of a series of events, that were generated by recipients when
interacting with the generated mobile landing page.  The set of events that are currently supported
are as follows:

| Event Type        | Event Source | Description                                    |
|:------------------|:-------------|:-----------------------------------------------|
| `PAGE_OPEN`       | n/a          | The page was opened in a browser.              |
| `BUTTON_CLICKED`  | Button label | One of the Call to Action buttons was clicked. |
| `FORM_SUBMITTED`  | n/a          | A form has been submitted with the captured data stored in the 'data' field. |Returns a list of events that have occurred for a particular campaign.

At this stage, the events are returned in reverse chronological order.

```csharp
GetCampaignEventsAsync(
    string campaignId,
    double? page = null,
    double? pageSize = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `campaignId` | `string` | Template, Required | The campaign ID |
| `page` | `double?` | Query, Optional | The page of results to retrieve.  If unspecified, defaults to 0. |
| `pageSize` | `double?` | Query, Optional | The size of each page.  Must be between 5 and 100.  Defaults to 25. |

## Response Type

[`Task<Models.ListCampaignEventPage>`](../../doc/models/list-campaign-event-page.md)

## Example Usage

```csharp
string campaignId = "campaign_id0";

try
{
    ListCampaignEventPage result = await mobileLandingPagesBetaController.GetCampaignEventsAsync(campaignId, null, null);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 402 | - | `ApiException` |
| 404 | - | `ApiException` |


# Get Templates Fields Definition

Returns a list of Template Field Definition.

```csharp
GetTemplatesFieldsDefinitionAsync(
    string id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | Template Id |

## Response Type

[`Task<Models.GetTemplatesFieldsDefinationresponse>`](../../doc/models/get-templates-fields-definationresponse.md)

## Example Usage

```csharp
string id = "id0";

try
{
    GetTemplatesFieldsDefinationresponse result = await mobileLandingPagesBetaController.GetTemplatesFieldsDefinitionAsync(id);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "fields": {
    "fontFamilyURL1": {
      "type": "TEXT"
    },
    "secondaryButtonTextColor": {
      "type": "TEXT"
    },
    "fontFamilyURL3": {
      "type": "TEXT"
    },
    "pageTitle": {
      "type": "TEXT"
    },
    "fontFamilyURL2": {
      "type": "TEXT"
    },
    "pageTextColor": {
      "type": "TEXT"
    },
    "barcodeHeight": {
      "type": "TEXT"
    },
    "imageHeaderUrl": {
      "type": "IMAGE"
    },
    "barcodeMargin": {
      "type": "TEXT"
    },
    "logoLink": {
      "type": "TEXT"
    },
    "primaryButtonLink": {
      "type": "TEXT"
    },
    "primaryButtonBackgroundColor": {
      "type": "TEXT"
    },
    "secondaryButtonLink": {
      "type": "TEXT"
    },
    "barcodeWidth": {
      "type": "TEXT"
    },
    "primaryButtonText": {
      "type": "TEXT"
    },
    "headline": {
      "type": "TEXT"
    },
    "headlineColor": {
      "type": "TEXT"
    },
    "pageText": {
      "type": "TEXT"
    },
    "secondaryButtonBackgroundColor": {
      "type": "TEXT"
    },
    "imageLinkPreviewUrl": {
      "type": "TEXT"
    },
    "pageTextFontFamily": {
      "type": "TEXT"
    },
    "secondaryButtonText": {
      "type": "TEXT"
    },
    "headlineFontFamily": {
      "type": "TEXT"
    },
    "barcodeLineColor": {
      "type": "TEXT"
    },
    "barcodeValue": {
      "type": "TEXT"
    },
    "primaryButtonTextColor": {
      "type": "TEXT"
    },
    "imageLogoUrl": {
      "type": "TEXT"
    },
    "barcodeDisplayValue": {
      "type": "TEXT"
    },
    "buttonFontFamily": {
      "type": "TEXT"
    }
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 402 | Account is not postpaid, or does not have Mobile Landing Pages Enabled. | `ApiException` |


# Get Templates

Returns a paginated list of Template.

```csharp
GetTemplatesAsync(
    string pageSize = null,
    string pageToken = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `pageSize` | `string` | Query, Optional | Page size between 5 and 100 (default 20) |
| `pageToken` | `string` | Query, Optional | Token to fetch the next page |

## Response Type

[`Task<Models.GetTemplatesresponse>`](../../doc/models/get-templatesresponse.md)

## Example Usage

```csharp
try
{
    GetTemplatesresponse result = await mobileLandingPagesBetaController.GetTemplatesAsync(null, null);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 402 | - | `ApiException` |


# Send Campaign to Recipients

Sends a campaign message to a group of recipients.

```csharp
SendCampaignToRecipientsAsync(
    string id,
    Models.BetaSmsplusCampaignsRecipientsRequest body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | - |
| `body` | [`Models.BetaSmsplusCampaignsRecipientsRequest`](../../doc/models/beta-smsplus-campaigns-recipients-request.md) | Body, Optional | - |

## Response Type

[`Task<Models.SendCampaignToRecipientsresponse>`](../../doc/models/send-campaign-to-recipientsresponse.md)

## Example Usage

```csharp
string id = "id0";

try
{
    SendCampaignToRecipientsresponse result = await mobileLandingPagesBetaController.SendCampaignToRecipientsAsync(id, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "recipients": [
    {
      "id": "05f81030-95fb-4c17-8736-ac73948e8b82",
      "number": "61491570156",
      "parameters": {
        "firstName": "John",
        "lastName": "English"
      }
    },
    {
      "id": "01261663-9428-4a1d-9798-e8a1877cc29d",
      "number": "61491570158",
      "parameters": {
        "firstName": "Mary",
        "lastName": "Example"
      }
    }
  ]
}
```


# Export Campaign Events Async

The reporting endpoint provides access to the reporting analytics.

### Events Types

The campaign report consists of a series of events, that were generated by recipients when
interacting with the generated mobile landing page.  The set of events that are currently supported
are as follows:

| Event Type        | Event Source | Description                                    |
|:------------------|:-------------|:-----------------------------------------------|
| `PAGE_OPEN`       | n/a          | The page was opened in a browser.              |
| `BUTTON_CLICKED`  | Button label | One of the Call to Action buttons was clicked. |
| `FORM_SUBMITTED`  | n/a          | A form has been submitted with the captured data stored in the 'data' field. |Produces an unpaginated CSV file of events that have occurred for a particular campaign and emails them to the specified address(es).

At this stage, the events are returned in reverse chronological order.

```csharp
ExportCampaignEventsAsyncAsync(
    string campaignId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `campaignId` | `string` | Template, Required | The campaign ID |

## Response Type

`Task`

## Example Usage

```csharp
string campaignId = "campaign_id0";

try
{
    await mobileLandingPagesBetaController.ExportCampaignEventsAsyncAsync(campaignId);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 402 | - | `ApiException` |
| 404 | - | `ApiException` |

