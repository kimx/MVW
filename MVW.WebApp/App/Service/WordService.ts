/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
module MVW.Service {
    export class WordService {
        private url: string = "/api/WordEntities";
        constructor(private $http: ng.IHttpService) {

        }

        Get(successCallback: Function) {
            this.$http.get(this.url).then((response) => {
                successCallback(response.data);
            });
        }

        GetClosedWordByLastDays(days: number, successCallback: Function) {
            this.$http.get(this.url, { params: { days } }).then((response) => {
                successCallback(response.data);
            });
        }

        Add(item, successCallback: Function) {
            this.$http.post(this.url, item).then((response) => {
                successCallback(response.data);
            });
        }

        Update(item, successCallback: Function) {
            this.$http.put(this.url + "/" + item.Id, item).then((response) => {
                successCallback(response.data);
            });
        }

        Delete(item, successCallback: Function) {
            this.$http.delete(this.url + "/" + item.Id).then((response) => {
                successCallback(response.data);
            });
        }
    }
}