namespace Palantir.TravisCI.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Palantir.Domain.Configurations;
    using Palantir.Domain.Models;
    using Xunit;

    public class RestApiServiceTests : IDisposable
    {
        private RestApiService travisCIService;

        private Build expectedBuildResponse;

        public RestApiServiceTests()
        {
            // Given
            List<string> travisCIUrl = new List<string>() { "https://api.travis-ci.org/repo/8722522/builds" };

            RestApiHeader travisCIHeader = new RestApiHeader()
            {
                AuthorizationToken = "o5EDKkh872Ws00tnILXAjg",
                UserAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36 OPR/38.0.2220.41",
                ApiVersion = "3",
            };

            this.travisCIService = new RestApiService(travisCIUrl, travisCIHeader);

            string travisCIResponse = "{\"@type\":\"builds\",\"@href\":\"/repo/8722522/builds\",\"@representation\":\"standard\",\"@pagination\":{\"limit\":25,\"offset\":0,\"count\":297,\"is_first\":true,\"is_last\":false,\"next\":{\"@href\":\"/repo/8722522/builds?limit=25&offset=25\",\"offset\":25,\"limit\":25},\"prev\":null,\"first\":{\"@href\":\"/repo/8722522/builds\",\"offset\":0,\"limit\":25},\"last\":{\"@href\":\"/repo/8722522/builds?limit=25&offset=275\",\"offset\":275,\"limit\":25}},\"builds\":[{\"@type\":\"build\",\"@href\":\"/build/631066056\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":631066056,\"number\":\"297\",\"state\":\"errored\",\"duration\":17,\"event_type\":\"pull_request\",\"previous_state\":\"passed\",\"pull_request_title\":\"Bump mustache from 2.1.3 to 3.2.1 in /archivos de ejemplo/plantilla\",\"pull_request_number\":1,\"started_at\":\"2019-12-30T20:23:06Z\",\"finished_at\":\"2019-12-30T20:23:23Z\",\"private\":false,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/master\",\"@representation\":\"minimal\",\"name\":\"master\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":191992323,\"sha\":\"7a5fa44078ef66782a72faa4ec477635cd2e2efb\",\"ref\":\"refs/pull/1/merge\",\"message\":\"Bump mustache from 2.1.3 to 3.2.1 in /archivos de ejemplo/plantilla\n\nBumps [mustache](https://github.com/janl/mustache.js) from 2.1.3 to 3.2.1.\n- [Release notes](https://github.com/janl/mustache.js/releases)\n- [Changelog](https://github.com/janl/mustache.js/blob/master/CHANGELOG.md)\n- [Commits](https://github.com/janl/mustache.js/compare/v2.1.3...v3.2.1)\n\nSigned-off-by: dependabot[bot] <support@github.com>\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/pull/1\",\"committed_at\":\"2019-12-30T20:22:32Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/631066057\",\"@representation\":\"minimal\",\"id\":631066057}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/1709451\",\"@representation\":\"minimal\",\"id\":1709451,\"login\":\"dependabot[bot]\"},\"updated_at\":\"2019-12-30T20:23:23.968Z\"},{\"@type\":\"build\",\"@href\":\"/build/631065999\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":631065999,\"number\":\"296\",\"state\":\"errored\",\"duration\":18,\"event_type\":\"push\",\"previous_state\":null,\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2019-12-30T20:23:01Z\",\"finished_at\":\"2019-12-30T20:23:19Z\",\"private\":false,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/dependabot%2Fnpm_and_yarn%2Farchivos-de-ejemplo%2Fplantilla%2Fmustache-3.2.1\",\"@representation\":\"minimal\",\"name\":\"dependabot/npm_and_yarn/archivos-de-ejemplo/plantilla/mustache-3.2.1\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":191992301,\"sha\":\"71fde5ef7323ab6c10ff577123036a71b062df9c\",\"ref\":\"refs/heads/dependabot/npm_and_yarn/archivos-de-ejemplo/plantilla/mustache-3.2.1\",\"message\":\"Bump mustache from 2.1.3 to 3.2.1 in /archivos de ejemplo/plantilla\n\nBumps [mustache](https://github.com/janl/mustache.js) from 2.1.3 to 3.2.1.\n- [Release notes](https://github.com/janl/mustache.js/releases)\n- [Changelog](https://github.com/janl/mustache.js/blob/master/CHANGELOG.md)\n- [Commits](https://github.com/janl/mustache.js/compare/v2.1.3...v3.2.1)\n\nSigned-off-by: dependabot[bot] <support@github.com>\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/commit/71fde5ef7323\",\"committed_at\":\"2019-12-30T20:22:32Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/631066001\",\"@representation\":\"minimal\",\"id\":631066001}],\"stages\":[],\"created_by\":null,\"updated_at\":\"2019-12-30T20:23:19.422Z\"},{\"@type\":\"build\",\"@href\":\"/build/138963890\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":138963890,\"number\":\"295\",\"state\":\"passed\",\"duration\":70,\"event_type\":\"push\",\"previous_state\":null,\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2016-06-20T17:06:09Z\",\"finished_at\":\"2016-06-20T17:07:19Z\",\"private\":null,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/v2\",\"@representation\":\"minimal\",\"name\":\"v2\"},\"tag\":{\"@type\":\"tag\",\"@representation\":\"minimal\",\"repository_id\":8722522,\"name\":\"v2\",\"last_build_id\":138963890},\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":39370903,\"sha\":\"0e755c0eb6303d27f4ce6b882a10e12ba4df938e\",\"ref\":\"refs/tags/v2\",\"message\":\"se hizo un cambio chiquito de redaccion en el Readme\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/compare/v2\",\"committed_at\":\"2016-06-20T17:02:23Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/138963894\",\"@representation\":\"minimal\",\"id\":138963894}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/339059\",\"@representation\":\"minimal\",\"id\":339059,\"login\":\"ferGainey\"},\"updated_at\":\"2019-04-13T05:32:43.461Z\"},{\"@type\":\"build\",\"@href\":\"/build/138963327\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":138963327,\"number\":\"294\",\"state\":\"passed\",\"duration\":71,\"event_type\":\"push\",\"previous_state\":\"passed\",\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2016-06-20T17:04:18Z\",\"finished_at\":\"2016-06-20T17:05:29Z\",\"private\":null,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/master\",\"@representation\":\"minimal\",\"name\":\"master\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":39370725,\"sha\":\"0e755c0eb6303d27f4ce6b882a10e12ba4df938e\",\"ref\":\"refs/heads/master\",\"message\":\"se hizo un cambio chiquito de redaccion en el Readme\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/compare/26692c983712...0e755c0eb630\",\"committed_at\":\"2016-06-20T17:02:23Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/138963328\",\"@representation\":\"minimal\",\"id\":138963328}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/339059\",\"@representation\":\"minimal\",\"id\":339059,\"login\":\"ferGainey\"},\"updated_at\":\"2019-04-13T05:32:43.461Z\"},{\"@type\":\"build\",\"@href\":\"/build/138953045\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":138953045,\"number\":\"293\",\"state\":\"passed\",\"duration\":69,\"event_type\":\"push\",\"previous_state\":\"passed\",\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2016-06-20T16:33:13Z\",\"finished_at\":\"2016-06-20T16:34:22Z\",\"private\":null,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/master\",\"@representation\":\"minimal\",\"name\":\"master\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":39368073,\"sha\":\"26692c983712c59f348c0bf11edb4fa4d8dba92b\",\"ref\":\"refs/heads/master\",\"message\":\"Correcion de estilo en archivo Markdown.\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/compare/c7bd210cac64...26692c983712\",\"committed_at\":\"2016-06-20T16:32:37Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/138953048\",\"@representation\":\"minimal\",\"id\":138953048}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/338652\",\"@representation\":\"minimal\",\"id\":338652,\"login\":\"gonzalocozzi\"},\"updated_at\":\"2019-04-13T05:32:43.461Z\"},{\"@type\":\"build\",\"@href\":\"/build/138951136\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":138951136,\"number\":\"292\",\"state\":\"passed\",\"duration\":63,\"event_type\":\"push\",\"previous_state\":\"passed\",\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2016-06-20T16:25:13Z\",\"finished_at\":\"2016-06-20T16:26:16Z\",\"private\":null,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/master\",\"@representation\":\"minimal\",\"name\":\"master\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":39367543,\"sha\":\"c7bd210cac645e638b2735edb999f87327dc6974\",\"ref\":\"refs/heads/master\",\"message\":\"se modifico el README y se agregaron comentarios al codigo\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/compare/96563a4f12bb...c7bd210cac64\",\"committed_at\":\"2016-06-20T16:24:08Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/138951137\",\"@representation\":\"minimal\",\"id\":138951137}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/339059\",\"@representation\":\"minimal\",\"id\":339059,\"login\":\"ferGainey\"},\"updated_at\":\"2019-04-13T05:32:43.461Z\"},{\"@type\":\"build\",\"@href\":\"/build/138925450\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":138925450,\"number\":\"291\",\"state\":\"passed\",\"duration\":110,\"event_type\":\"push\",\"previous_state\":\"passed\",\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2016-06-20T14:54:01Z\",\"finished_at\":\"2016-06-20T14:55:51Z\",\"private\":null,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/master\",\"@representation\":\"minimal\",\"name\":\"master\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":39360396,\"sha\":\"96563a4f12bb33ac663ca41345e73af242f8acf9\",\"ref\":\"refs/heads/master\",\"message\":\"Nuevas modificaciones al archivo README.md\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/compare/46abf351621d...96563a4f12bb\",\"committed_at\":\"2016-06-20T14:51:52Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/138925452\",\"@representation\":\"minimal\",\"id\":138925452}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/338652\",\"@representation\":\"minimal\",\"id\":338652,\"login\":\"gonzalocozzi\"},\"updated_at\":\"2019-04-13T05:32:43.461Z\"},{\"@type\":\"build\",\"@href\":\"/build/138920440\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":138920440,\"number\":\"290\",\"state\":\"passed\",\"duration\":82,\"event_type\":\"push\",\"previous_state\":\"passed\",\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2016-06-20T14:34:41Z\",\"finished_at\":\"2016-06-20T14:36:03Z\",\"private\":null,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/master\",\"@representation\":\"minimal\",\"name\":\"master\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":39359008,\"sha\":\"46abf351621d8cc89dda8e56b48b00666b18b519\",\"ref\":\"refs/heads/master\",\"message\":\"Nuevas modificaciones al archivo README.md\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/compare/52f22a63dc25...46abf351621d\",\"committed_at\":\"2016-06-20T14:33:16Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/138920441\",\"@representation\":\"minimal\",\"id\":138920441}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/338652\",\"@representation\":\"minimal\",\"id\":338652,\"login\":\"gonzalocozzi\"},\"updated_at\":\"2019-04-13T05:32:43.461Z\"},{\"@type\":\"build\",\"@href\":\"/build/138806873\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":138806873,\"number\":\"289\",\"state\":\"passed\",\"duration\":59,\"event_type\":\"push\",\"previous_state\":\"passed\",\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2016-06-20T03:24:19Z\",\"finished_at\":\"2016-06-20T03:25:18Z\",\"private\":null,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/master\",\"@representation\":\"minimal\",\"name\":\"master\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":39326927,\"sha\":\"52f22a63dc250f463a65d515abf1120dafc445ea\",\"ref\":\"refs/heads/master\",\"message\":\"redaccion del README.md\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/compare/f3969604d217...52f22a63dc25\",\"committed_at\":\"2016-06-20T03:23:40Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/138806874\",\"@representation\":\"minimal\",\"id\":138806874}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/338825\",\"@representation\":\"minimal\",\"id\":338825,\"login\":\"JulianMoreno2\"},\"updated_at\":\"2019-04-13T05:32:43.461Z\"},{\"@type\":\"build\",\"@href\":\"/build/138516836\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":138516836,\"number\":\"288\",\"state\":\"passed\",\"duration\":72,\"event_type\":\"push\",\"previous_state\":\"passed\",\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2016-06-18T01:16:30Z\",\"finished_at\":\"2016-06-18T01:17:42Z\",\"private\":null,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/master\",\"@representation\":\"minimal\",\"name\":\"master\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":39244633,\"sha\":\"f3969604d2179af1c163ab48a484ac46f0fd1247\",\"ref\":\"refs/heads/master\",\"message\":\"Agregado diagrama de clases. Renombrados diagramas de secuencia.\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/compare/60eb2215aa25...f3969604d217\",\"committed_at\":\"2016-06-18T01:16:10Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/138516837\",\"@representation\":\"minimal\",\"id\":138516837}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/338652\",\"@representation\":\"minimal\",\"id\":338652,\"login\":\"gonzalocozzi\"},\"updated_at\":\"2019-04-13T05:32:43.461Z\"},{\"@type\":\"build\",\"@href\":\"/build/138515309\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":138515309,\"number\":\"287\",\"state\":\"passed\",\"duration\":56,\"event_type\":\"push\",\"previous_state\":\"passed\",\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2016-06-18T01:03:35Z\",\"finished_at\":\"2016-06-18T01:04:31Z\",\"private\":null,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/master\",\"@representation\":\"minimal\",\"name\":\"master\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":39244234,\"sha\":\"60eb2215aa25eb748b62d12d7d13006398dc9530\",\"ref\":\"refs/heads/master\",\"message\":\"Correciones menores de estilo en diversas clases.\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/compare/6daf785a966d...60eb2215aa25\",\"committed_at\":\"2016-06-18T01:03:17Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/138515310\",\"@representation\":\"minimal\",\"id\":138515310}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/338652\",\"@representation\":\"minimal\",\"id\":338652,\"login\":\"gonzalocozzi\"},\"updated_at\":\"2019-04-13T05:32:43.461Z\"},{\"@type\":\"build\",\"@href\":\"/build/138509921\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":138509921,\"number\":\"286\",\"state\":\"passed\",\"duration\":64,\"event_type\":\"push\",\"previous_state\":\"passed\",\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2016-06-18T00:13:47Z\",\"finished_at\":\"2016-06-18T00:14:51Z\",\"private\":null,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/master\",\"@representation\":\"minimal\",\"name\":\"master\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":39242777,\"sha\":\"6daf785a966d10a2d03b1d912611488570d14621\",\"ref\":\"refs/heads/master\",\"message\":\"elimino diagrama de secuencia obsoleto\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/compare/667f82ab7ef3...6daf785a966d\",\"committed_at\":\"2016-06-18T00:13:34Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/138509922\",\"@representation\":\"minimal\",\"id\":138509922}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/338825\",\"@representation\":\"minimal\",\"id\":338825,\"login\":\"JulianMoreno2\"},\"updated_at\":\"2019-04-13T05:32:43.461Z\"},{\"@type\":\"build\",\"@href\":\"/build/138509907\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":138509907,\"number\":\"285\",\"state\":\"passed\",\"duration\":51,\"event_type\":\"push\",\"previous_state\":\"passed\",\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2016-06-18T00:13:35Z\",\"finished_at\":\"2016-06-18T00:14:26Z\",\"private\":null,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/master\",\"@representation\":\"minimal\",\"name\":\"master\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":39242770,\"sha\":\"667f82ab7ef31104101c5eb75ba4963c9ca27c67\",\"ref\":\"refs/heads/master\",\"message\":\"elimino diagrama de secuencia obsoleto\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/compare/952fcdeeb0a6...667f82ab7ef3\",\"committed_at\":\"2016-06-18T00:13:18Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/138509908\",\"@representation\":\"minimal\",\"id\":138509908}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/338825\",\"@representation\":\"minimal\",\"id\":338825,\"login\":\"JulianMoreno2\"},\"updated_at\":\"2019-04-13T05:32:43.461Z\"},{\"@type\":\"build\",\"@href\":\"/build/138509663\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":138509663,\"number\":\"284\",\"state\":\"passed\",\"duration\":65,\"event_type\":\"push\",\"previous_state\":\"passed\",\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2016-06-18T00:12:04Z\",\"finished_at\":\"2016-06-18T00:13:09Z\",\"private\":null,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/master\",\"@representation\":\"minimal\",\"name\":\"master\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":39242709,\"sha\":\"952fcdeeb0a6c1349fdcee0ec823d30dff989c28\",\"ref\":\"refs/heads/master\",\"message\":\"modifico los diagramas de secuencia de acuerdo al codigo agregado en el refactor\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/compare/1db1e480f55b...952fcdeeb0a6\",\"committed_at\":\"2016-06-18T00:11:14Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/138509664\",\"@representation\":\"minimal\",\"id\":138509664}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/338825\",\"@representation\":\"minimal\",\"id\":338825,\"login\":\"JulianMoreno2\"},\"updated_at\":\"2019-04-13T05:32:43.461Z\"},{\"@type\":\"build\",\"@href\":\"/build/138507743\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":138507743,\"number\":\"283\",\"state\":\"passed\",\"duration\":56,\"event_type\":\"push\",\"previous_state\":\"passed\",\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2016-06-17T23:57:59Z\",\"finished_at\":\"2016-06-17T23:58:55Z\",\"private\":null,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/master\",\"@representation\":\"minimal\",\"name\":\"master\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":39242167,\"sha\":\"1db1e480f55b8701589eba6aaff9f4cc974aa2b0\",\"ref\":\"refs/heads/master\",\"message\":\"Correciones menores de estilo en la clase Traductor.\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/compare/ec10087c27aa...1db1e480f55b\",\"committed_at\":\"2016-06-17T23:57:35Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/138507744\",\"@representation\":\"minimal\",\"id\":138507744}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/338652\",\"@representation\":\"minimal\",\"id\":338652,\"login\":\"gonzalocozzi\"},\"updated_at\":\"2019-04-13T05:32:43.461Z\"},{\"@type\":\"build\",\"@href\":\"/build/138503537\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":138503537,\"number\":\"282\",\"state\":\"passed\",\"duration\":67,\"event_type\":\"push\",\"previous_state\":\"passed\",\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2016-06-17T23:36:16Z\",\"finished_at\":\"2016-06-17T23:37:23Z\",\"private\":null,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/master\",\"@representation\":\"minimal\",\"name\":\"master\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":39240990,\"sha\":\"ec10087c27aa2a2098de1b6f92ab660393975d6e\",\"ref\":\"refs/heads/master\",\"message\":\"Correcciones de alineacion y nombre de metodos.\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/compare/659ec7a80768...ec10087c27aa\",\"committed_at\":\"2016-06-17T23:34:21Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/138503539\",\"@representation\":\"minimal\",\"id\":138503539}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/338652\",\"@representation\":\"minimal\",\"id\":338652,\"login\":\"gonzalocozzi\"},\"updated_at\":\"2019-04-13T05:32:43.461Z\"},{\"@type\":\"build\",\"@href\":\"/build/138107643\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":138107643,\"number\":\"281\",\"state\":\"passed\",\"duration\":73,\"event_type\":\"push\",\"previous_state\":\"passed\",\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2016-06-16T14:57:03Z\",\"finished_at\":\"2016-06-16T14:58:16Z\",\"private\":null,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/master\",\"@representation\":\"minimal\",\"name\":\"master\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":39128807,\"sha\":\"659ec7a80768b44c18b5e2d44d33a7351ad79255\",\"ref\":\"refs/heads/master\",\"message\":\"Reemplazado SelectorDeModo con Traductor.\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/compare/3e0b3657bf12...659ec7a80768\",\"committed_at\":\"2016-06-16T14:56:18Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/138107644\",\"@representation\":\"minimal\",\"id\":138107644}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/338652\",\"@representation\":\"minimal\",\"id\":338652,\"login\":\"gonzalocozzi\"},\"updated_at\":\"2019-04-13T05:32:43.461Z\"},{\"@type\":\"build\",\"@href\":\"/build/138105342\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":138105342,\"number\":\"280\",\"state\":\"passed\",\"duration\":66,\"event_type\":\"push\",\"previous_state\":\"passed\",\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2016-06-16T14:49:08Z\",\"finished_at\":\"2016-06-16T14:50:14Z\",\"private\":null,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/master\",\"@representation\":\"minimal\",\"name\":\"master\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":39128145,\"sha\":\"3e0b3657bf12ed5810f02f345cc5f2e23d731a69\",\"ref\":\"refs/heads/master\",\"message\":\"Traductor almacena nuevo modo de salida.\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/compare/3a08f47aaef1...3e0b3657bf12\",\"committed_at\":\"2016-06-16T14:48:22Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/138105343\",\"@representation\":\"minimal\",\"id\":138105343}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/338652\",\"@representation\":\"minimal\",\"id\":338652,\"login\":\"gonzalocozzi\"},\"updated_at\":\"2019-04-13T05:32:43.461Z\"},{\"@type\":\"build\",\"@href\":\"/build/138104476\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":138104476,\"number\":\"279\",\"state\":\"passed\",\"duration\":65,\"event_type\":\"push\",\"previous_state\":\"passed\",\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2016-06-16T14:46:16Z\",\"finished_at\":\"2016-06-16T14:47:21Z\",\"private\":null,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/master\",\"@representation\":\"minimal\",\"name\":\"master\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":39127913,\"sha\":\"3a08f47aaef10b072f5c7d7af63c00d2b17945f2\",\"ref\":\"refs/heads/master\",\"message\":\"Traductor almacena argumento en su lista de argumentos.\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/compare/c2616089fb7c...3a08f47aaef1\",\"committed_at\":\"2016-06-16T14:45:28Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/138104477\",\"@representation\":\"minimal\",\"id\":138104477}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/338652\",\"@representation\":\"minimal\",\"id\":338652,\"login\":\"gonzalocozzi\"},\"updated_at\":\"2019-04-13T05:32:43.461Z\"},{\"@type\":\"build\",\"@href\":\"/build/138102360\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":138102360,\"number\":\"278\",\"state\":\"passed\",\"duration\":84,\"event_type\":\"push\",\"previous_state\":\"passed\",\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2016-06-16T14:39:17Z\",\"finished_at\":\"2016-06-16T14:40:41Z\",\"private\":null,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/master\",\"@representation\":\"minimal\",\"name\":\"master\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":39127320,\"sha\":\"c2616089fb7c187ac13c7393269e967d7be5b693\",\"ref\":\"refs/heads/master\",\"message\":\"[TRIO PROGRAMMING] ModoDeSalidaDefault escribe salida HTML en archivo.\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/compare/97b943e664a2...c2616089fb7c\",\"committed_at\":\"2016-06-16T14:38:44Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/138102361\",\"@representation\":\"minimal\",\"id\":138102361}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/338652\",\"@representation\":\"minimal\",\"id\":338652,\"login\":\"gonzalocozzi\"},\"updated_at\":\"2019-04-13T05:32:43.461Z\"},{\"@type\":\"build\",\"@href\":\"/build/138098473\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":138098473,\"number\":\"277\",\"state\":\"passed\",\"duration\":69,\"event_type\":\"push\",\"previous_state\":\"passed\",\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2016-06-16T14:26:38Z\",\"finished_at\":\"2016-06-16T14:27:47Z\",\"private\":null,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/master\",\"@representation\":\"minimal\",\"name\":\"master\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":39126226,\"sha\":\"97b943e664a2c0aa3610ba41c787612bc332f8b4\",\"ref\":\"refs/heads/master\",\"message\":\"[TRIO PROGRAMMING] ModoDeSalidNoOutput devuelve por consola salida HTML esperada.\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/compare/bd0b099813c6...97b943e664a2\",\"committed_at\":\"2016-06-16T14:25:46Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/138098474\",\"@representation\":\"minimal\",\"id\":138098474}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/338652\",\"@representation\":\"minimal\",\"id\":338652,\"login\":\"gonzalocozzi\"},\"updated_at\":\"2019-04-13T05:32:43.461Z\"},{\"@type\":\"build\",\"@href\":\"/build/138091646\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":138091646,\"number\":\"276\",\"state\":\"passed\",\"duration\":69,\"event_type\":\"push\",\"previous_state\":\"passed\",\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2016-06-16T14:02:29Z\",\"finished_at\":\"2016-06-16T14:03:38Z\",\"private\":null,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/master\",\"@representation\":\"minimal\",\"name\":\"master\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":39124205,\"sha\":\"bd0b099813c66646a4f03acbbcf0f2a4060da135\",\"ref\":\"refs/heads/master\",\"message\":\"Creacion de paquetes por correspondencia con el dominio en la carpeta de test.\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/compare/ca905d457cf9...bd0b099813c6\",\"committed_at\":\"2016-06-16T14:01:04Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/138091647\",\"@representation\":\"minimal\",\"id\":138091647}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/338652\",\"@representation\":\"minimal\",\"id\":338652,\"login\":\"gonzalocozzi\"},\"updated_at\":\"2019-04-13T05:32:43.461Z\"},{\"@type\":\"build\",\"@href\":\"/build/138089597\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":138089597,\"number\":\"275\",\"state\":\"passed\",\"duration\":68,\"event_type\":\"push\",\"previous_state\":\"passed\",\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2016-06-16T13:54:49Z\",\"finished_at\":\"2016-06-16T13:55:57Z\",\"private\":null,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/master\",\"@representation\":\"minimal\",\"name\":\"master\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":39123604,\"sha\":\"ca905d457cf9d856c2bd9200376f01d475678ab2\",\"ref\":\"refs/heads/master\",\"message\":\"SinNombreDelArchivoDeEntradaException sabe cuando debe lanzarse.\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/compare/3880eac75587...ca905d457cf9\",\"committed_at\":\"2016-06-16T13:53:52Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/138089600\",\"@representation\":\"minimal\",\"id\":138089600}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/338652\",\"@representation\":\"minimal\",\"id\":338652,\"login\":\"gonzalocozzi\"},\"updated_at\":\"2019-04-13T05:32:43.461Z\"},{\"@type\":\"build\",\"@href\":\"/build/138089183\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":138089183,\"number\":\"274\",\"state\":\"passed\",\"duration\":60,\"event_type\":\"push\",\"previous_state\":\"passed\",\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2016-06-16T13:53:50Z\",\"finished_at\":\"2016-06-16T13:54:50Z\",\"private\":null,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/master\",\"@representation\":\"minimal\",\"name\":\"master\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":39123494,\"sha\":\"3880eac755876623c7d8b4b91552db819dce0679\",\"ref\":\"refs/heads/master\",\"message\":\"NumeroDeArgumentosInvalidoException sabe cuando debe lanzarse.\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/compare/6ae673ec8f7d...3880eac75587\",\"committed_at\":\"2016-06-16T13:52:48Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/138089184\",\"@representation\":\"minimal\",\"id\":138089184}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/338652\",\"@representation\":\"minimal\",\"id\":338652,\"login\":\"gonzalocozzi\"},\"updated_at\":\"2019-04-13T05:32:43.461Z\"},{\"@type\":\"build\",\"@href\":\"/build/138088236\",\"@representation\":\"standard\",\"@permissions\":{\"read\":true,\"cancel\":true,\"restart\":true},\"id\":138088236,\"number\":\"273\",\"state\":\"passed\",\"duration\":70,\"event_type\":\"push\",\"previous_state\":\"passed\",\"pull_request_title\":null,\"pull_request_number\":null,\"started_at\":\"2016-06-16T13:50:33Z\",\"finished_at\":\"2016-06-16T13:51:43Z\",\"private\":null,\"repository\":{\"@type\":\"repository\",\"@href\":\"/repo/8722522\",\"@representation\":\"minimal\",\"id\":8722522,\"name\":\"aydoo-2016-e4\",\"slug\":\"gonzalocozzi/aydoo-2016-e4\"},\"branch\":{\"@type\":\"branch\",\"@href\":\"/repo/8722522/branch/master\",\"@representation\":\"minimal\",\"name\":\"master\"},\"tag\":null,\"commit\":{\"@type\":\"commit\",\"@representation\":\"minimal\",\"id\":39123205,\"sha\":\"6ae673ec8f7d0c9db2e96039b129c7219ac3e799\",\"ref\":\"refs/heads/master\",\"message\":\"ArgumentoInvalidoException sabe cuando debe lanzarse.\",\"compare_url\":\"https://github.com/gonzalocozzi/aydoo-2016-e4/compare/56ec48205d3a...6ae673ec8f7d\",\"committed_at\":\"2016-06-16T13:49:10Z\"},\"jobs\":[{\"@type\":\"job\",\"@href\":\"/job/138088237\",\"@representation\":\"minimal\",\"id\":138088237}],\"stages\":[],\"created_by\":{\"@type\":\"user\",\"@href\":\"/user/338652\",\"@representation\":\"minimal\",\"id\":338652,\"login\":\"gonzalocozzi\"},\"updated_at\":\"2019-04-13T05:32:43.461Z\"}]}";

            TravisCIBuild travisCIBuild = JsonConvert.DeserializeObject<TravisCIBuild>(travisCIResponse);

            BuildAdapter adapter = new BuildAdapter();
            this.expectedBuildResponse = adapter.GetBuild(travisCIBuild.Builds.First());
        }

        public void Dispose()
        {
            this.travisCIService = null;
            this.expectedBuildResponse = null;
        }

        [Fact]
        public void ReturnsBuildResponseFromTravisCI()
        {
            // When
            List<Build> response = this.travisCIService.GetBuilds();
            string responseJson = JsonConvert.SerializeObject(response.FirstOrDefault());
            string expectedResponseJson = JsonConvert.SerializeObject(this.expectedBuildResponse);

            // Then
            Assert.Equal(expectedResponseJson, responseJson);
        }
    }
}