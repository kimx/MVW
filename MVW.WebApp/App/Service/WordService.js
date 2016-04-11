/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
var MVW;
(function (MVW) {
    var Service;
    (function (Service) {
        var WordService = (function () {
            function WordService($http) {
                this.$http = $http;
                this.url = "/api/WordEntities";
            }
            WordService.prototype.Get = function (successCallback) {
                this.$http.get(this.url).then(function (response) {
                    successCallback(response.data);
                });
            };
            WordService.prototype.GetClosedWordByLastDays = function (days, successCallback) {
                this.$http.get(this.url, { params: { days: days } }).then(function (response) {
                    successCallback(response.data);
                });
            };
            WordService.prototype.Add = function (item, successCallback) {
                this.$http.post(this.url, item).then(function (response) {
                    successCallback(response.data);
                });
            };
            WordService.prototype.Update = function (item, successCallback) {
                this.$http.put(this.url + "/" + item.Id, item).then(function (response) {
                    successCallback(response.data);
                });
            };
            WordService.prototype.Delete = function (item, successCallback) {
                this.$http.delete(this.url + "/" + item.Id).then(function (response) {
                    successCallback(response.data);
                });
            };
            return WordService;
        }());
        Service.WordService = WordService;
    })(Service = MVW.Service || (MVW.Service = {}));
})(MVW || (MVW = {}));
//# sourceMappingURL=WordService.js.map