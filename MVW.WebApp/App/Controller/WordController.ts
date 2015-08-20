/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
module MVW.Controller {
    export class WordController {
        List: Array<any>;
        ClosedList: Array<any>;
        Main: any;
        constructor(private $scope: ng.IScope, private WordService: Service.WordService) {
            this.List = [];
            this.Main = {};
        }

        Init() {
            this.Query();
            console.log("this.top:" + $("#blockWrap").position().top);
            console.log("footer.top:" + $("footer").position().top);
            $("#blockWrap").css("height",($("footer").position().top - $("#blockWrap").position().top) + "px");
        }


        Query() {
            this.WordService.Get((data) => {
                this.List = data;
            });

            this.WordService.GetClosedWordByLastDays(7,(data) => {
                this.ClosedList = data;
            });
        }

        ToggleShow(item, $event) {
            if (item.ShowToWord)
                item.ShowToWord = false;
            else
                item.ShowToWord = true;

            console.log($($event.currentTarget).next("input").length);
            setTimeout(() => { $("#txtEditFromWord").focus(); }, 100);
        }

        Add() {
            this.WordService.Add(this.Main,(res) => {
                this.Main = {};
                this.Query();
                $("#txtAddFromWord").focus();
            });
        }

        InCreaseTimes(item) {
            item.KnowTimes += 1;
            this.WordService.Update(item,(res) => {
                this.Query();
            });
        }

        DeCreaseTimes(item) {
            item.KnowTimes -= 1;
            this.WordService.Update(item,(res) => {
                this.Query();
            });
        }

        Translate(item) {
            var url = "https://translate.google.com.tw/?hl=zh-TW#en/zh-TW/" + item.FromWord;
            window.open(url);
        }

        TranslateByYahoo(item) {
            var url = "http://tw.dictionary.search.yahoo.com/search?p=" + item.FromWord + "&fr2=dict";
            window.open(url);
        }

        Delete(item) {
            this.WordService.Delete(item,(res) => {
                this.Query();
            });
        }

        Update($event, item) {
            if ($event.keyCode == 27)//esc
            {
                item.ShowToWord = false;
                return;
            }
            if ($event.keyCode != 13)
                return;

            this.WordService.Update(item,(res) => {
                item.ShowToWord = false;
            });
        }
        Closed(item) {
            item.Closed = true;
            this.WordService.Update(item,(res) => {

                this.Query();
            });
        }

        Star(item) {
            item.Star = true;
            this.WordService.Update(item,(res) => {

            });
        }

        UnStar(item) {
            item.Star = false;
            this.WordService.Update(item,(res) => {

            });
        }

    }
}