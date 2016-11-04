(function () {
    'use strict';

    angular
        .module('app')
        .controller('categoriesCtrl', CategoriesCtrl);

    function CategoriesCtrl($scope, CategoryService) {
        var vm = this;
        vm.removeCategory = function (id) {
            //vm.categories.splice(index, 1);
            CategoryService.remove(id).then(function (result) {
                console.log(result);
            });
        };
        vm.addCategory = function () {
            vm.inserted = {
                CategoryName: '',
                CategoryDescription: ''
            };
            vm.categories.push(vm.inserted);
        };

        vm.save = function (id, category) {
            var data = {
                "CategoryName": category.CategoryName,
                "CategoryDescription": category.CategoryDescription
            };
            if (id) {
                data.CategoryId = id;
                CategoryService.save(data).then(function (result) {
                    console.log(result);
                });
            } else {
                CategoryService.create(data).then(function (result) {
                    console.log(result);
                });
            }
        };

        vm.getCategories = function () {
            var ret = CategoryService.getAll();
            ret.then(function (result) {
                vm.categories = result.Categories;
            }, showError);
        };

        function showError(errObj) {
            if (window.console) {
                console.log(errObj, "Failed to retrieve category list. Please try again later.");
            }
            $scope.messages = [{
                msg: 'Failed to retrieve category list',
                type: 'danger'
            }];
        }

        vm.getCategories();

    }

})();