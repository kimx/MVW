/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
var MVW;
(function (MVW) {
    var Controller;
    (function (Controller) {
        var WordController = (function () {
            function WordController($scope, WordService) {
                this.$scope = $scope;
                this.WordService = WordService;
                this.List = [];
                this.Main = {};
            }
            WordController.prototype.Init = function () {
                this.Query();
                console.log("this.top:" + $("#blockWrap").position().top);
                console.log("footer.top:" + $("footer").position().top);
                $("#blockWrap").css("height", ($("footer").position().top - $("#blockWrap").position().top) + "px");
            };
            WordController.prototype.Query = function () {
                var _this = this;
                this.WordService.Get(function (data) {
                    _this.List = data;
                });
                this.WordService.GetClosedWordByLastDays(7, function (data) {
                    _this.ClosedList = data;
                });
            };
            WordController.prototype.ToggleShow = function (item, $event) {
                if (item.ShowToWord)
                    item.ShowToWord = false;
                else
                    item.ShowToWord = true;
                console.log($($event.currentTarget).next("input").length);
                setTimeout(function () {
                    $("#txtEditFromWord").focus();
                }, 100);
            };
            WordController.prototype.Add = function () {
                var _this = this;
                this.WordService.Add(this.Main, function (res) {
                    _this.Main = {};
                    _this.Query();
                    $("#txtAddFromWord").focus();
                });
            };
            WordController.prototype.InCreaseTimes = function (item) {
                var _this = this;
                item.KnowTimes += 1;
                this.WordService.Update(item, function (res) {
                    _this.Query();
                });
            };
            WordController.prototype.DeCreaseTimes = function (item) {
                var _this = this;
                item.KnowTimes -= 1;
                this.WordService.Update(item, function (res) {
                    _this.Query();
                });
            };
            WordController.prototype.Translate = function (item) {
                var url = "https://translate.google.com.tw/?hl=zh-TW#en/zh-TW/" + item.FromWord;
                window.open(url);
            };
            WordController.prototype.TranslateByYahoo = function (item) {
                var url = "http://tw.dictionary.search.yahoo.com/search?p=" + item.FromWord + "&fr2=dict";
                window.open(url);
            };
            WordController.prototype.Delete = function (item) {
                var _this = this;
                this.WordService.Delete(item, function (res) {
                    _this.Query();
                });
            };
            WordController.prototype.Update = function ($event, item) {
                if ($event.keyCode == 27) {
                    item.ShowToWord = false;
                    return;
                }
                if ($event.keyCode != 13)
                    return;
                this.WordService.Update(item, function (res) {
                    item.ShowToWord = false;
                });
            };
            WordController.prototype.Closed = function (item) {
                var _this = this;
                item.Closed = true;
                this.WordService.Update(item, function (res) {
                    _this.Query();
                });
            };
            WordController.prototype.Star = function (item) {
                item.Star = true;
                this.WordService.Update(item, function (res) {
                });
            };
            WordController.prototype.UnStar = function (item) {
                item.Star = false;
                this.WordService.Update(item, function (res) {
                });
            };
            return WordController;
        })();
        Controller.WordController = WordController;
    })(Controller = MVW.Controller || (MVW.Controller = {}));
})(MVW || (MVW = {}));
//# sourceMappingURL=WordController.js.map