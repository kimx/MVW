var MVW;
(function (MVW) {
    var App = (function () {
        function App() {
            var app = angular.module("app", ["ngMessages", "ngRoute"]);
            app.config(["$routeProvider", this.Config]);
            app.service("WordService", ['$http', MVW.Service.WordService]);
            app.controller("WordController", ['$scope', 'WordService', MVW.Controller.WordController]);
        }
        App.prototype.Config = function ($routeProvider) {
            $routeProvider
                .when('/', { templateUrl: "/Word", controller: "WordController", controllerAs: "vm" })
                .otherwise({ redirectTo: "/" });
        };
        return App;
    }());
    MVW.App = App;
})(MVW || (MVW = {}));
//# sourceMappingURL=App.js.map