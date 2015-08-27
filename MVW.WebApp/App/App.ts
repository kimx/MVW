module MVW {
    export class App {
        constructor() {
            var app = angular.module("app", ["ngMessages", "ngRoute"]);
            app.config(["$routeProvider", this.Config])
            app.service("WordService", ['$http', Service.WordService]);
            app.controller("WordController", ['$scope', 'WordService', Controller.WordController]);
        }

        Config($routeProvider: ng.route.IRouteProvider) {
            $routeProvider
                .when('/', { templateUrl: "/Word", controller: "WordController", controllerAs: "vm" })
                .otherwise({ redirectTo: "/" });
        }
    }
} 