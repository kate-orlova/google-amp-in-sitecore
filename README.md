# Google AMP in Sitecore module
Google AMP in Sitecore module is an open source project supporting the Google Accelerated Mobile Pages (AMP) integration with Sitecore.

The module covers the following aspects:
1. AMP view is based on a dedicated AMP Layout with limited AMP HTML, JavaScript and CSS;
2. Each AMP page has its unique URL as per [AMP guidelines](https://support.google.com/webmasters/answer/6340290?hl=en), for example, an "/amp/" suffix can be added to the standard page URL;
3. Page content is shared between non-AMP and AMP views, so no changes to the ordinary content management process.

The solution has been designed based on the standard Sitecore pipeline principle and the exact implementation overrides three Sitecore pipelines:
1. httpRequestBegin
2. mvc.buildPageDefinition
3. mvc.renderRendering

## Sitecore Pipelines

### httpRequestBegin
_..\src\Project\MyProject\Resolvers\AmpItemResolver.cs_

Checks whether it is an AMP request by "/amp/" URL suffix or not and, if a resolved item has an AMP view, sets an AMP flag to true.

### mvc.buildPageDefinition
_..\src\Project\MyProject\Resolvers\AmpProcessXmlBasedLayoutDefinition.cs_

Substitutes a normal Layout with the AMP one for AMP requests on the fly.

### mvc.renderRendering
_..\src\Project\MyProject\Pipelines\ApplyVaryByAmp.cs_

Extends the standard Vary By Param cache option to support AMP view.

## AMP Config
_..\src\Project\MyProject\App_Config\Include\MyProject.Amp.config_

AMP specific config consists of the above pipelines definition and AMP Layout Id.

## AMP compatible components
_ContentComponents_ project contains the content components supporting the AMP view, for example _..\src\Feature\ContentComponents\Views\YouTubeVideo.cshtml_ demonstrates how to render a YouTube video for AMP.
Check of the current context by _Context.IsAmpRequest()_ method will allow to adopt the already existing components for AMP view with minimal efforts.

# Contribution
Hope you found the above solution elegant and helpful, your contributions and suggestions will be very much appreciated. Please submit a pull request.
