[![GitHub release](https://img.shields.io/github/release-date/kate-orlova/google-amp-in-sitecore.svg?style=flat)](https://github.com/kate-orlova/google-amp-in-sitecore/releases/tag/MVPRelease)
[![GitHub license](https://img.shields.io/github/license/kate-orlova/google-amp-in-sitecore.svg)](https://github.com/kate-orlova/google-amp-in-sitecore/blob/master/LICENSE)
![GitHub language count](https://img.shields.io/github/languages/count/kate-orlova/google-amp-in-sitecore.svg?style=flat)
![GitHub top language](https://img.shields.io/github/languages/top/kate-orlova/google-amp-in-sitecore.svg?style=flat)
![HitHub repo size](https://img.shields.io/github/repo-size/kate-orlova/google-amp-in-sitecore.svg?style=flat)

# Google AMP in Sitecore module
Google AMP in Sitecore module is an open source project supporting the Google Accelerated Mobile Pages (AMP) integration with Sitecore.

The module covers the following aspects:
1. AMP view of a Sitecore page is based on a dedicated AMP Layout with limited AMP HTML, JavaScript and CSS as per [AMP HTML specification](https://www.ampproject.org/docs/fundamentals/spec);
2. Each AMP page has its unique URL as per [AMP guidelines](https://support.google.com/webmasters/answer/6340290?hl=en), for example, an _"/amp/"_ suffix can be added to the standard page URL;
3. Page content is shared between non-AMP and AMP views, so no changes to the ordinary content management process.

The fundamental design of this solution is based on the standard Sitecore pipeline principle and this implementation overrides three Sitecore pipelines:
1. httpRequestBegin
2. mvc.buildPageDefinition
3. mvc.renderRendering

## Sitecore Pipelines

### httpRequestBegin
_..\src\Project\MyProject\Resolvers\AmpItemResolver.cs_

Checks whether it is an AMP request by _"/amp/"_ URL suffix or not and, if a resolved item has an AMP view, sets an AMP flag to true.

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
_ContentComponents_ project contains the content components supporting the AMP view:
* YouTubeVideo
* SocialLinks
* InlineImage
* BackgroundImageResponsive
* BackgroundVideo

For example _..\src\Feature\ContentComponents\Views\YouTubeVideo.cshtml_ demonstrates how to render a YouTube video for AMP.
Check of the current context by _Context.IsAmpRequest()_ method will allow to adopt the already existing components for AMP view with minimal efforts.

All components have the embeded microdata to render a structured data in JSON format and help Google to understand the content of the page where they are placed on. [Schema.NET version 3.6.0](https://www.nuget.org/packages/Schema.NET/) package has been used for Schema.org objects in .NET classes.

# Contribution
Hope you found the above solution elegant and helpful, your contributions and suggestions will be very much appreciated. Please submit a pull request.

# License
The Google AMP in Sitecore module is released under the MIT license what means that you can modify and use it how you want even for commercial use. Please give it a star if you like it and your experience was positive.

