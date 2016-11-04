(function () {
    'use strict';

    app.factory('CategoryService', Service);

    function Service($resource) {
        var odataUrl = '/odata/Categories';
        return $resource('', {},
            {
                'getAll': { method: 'GET', url: odataUrl },
                'getTop10': { method: 'GET', url: odataUrl + '?$top=10' },
                'getCategoryByName': { method: 'GET', params: { key: '@key' }, url: odataUrl + '?$filter=Name eq %27' + ':key' + '%27' },
                'create': { method: 'POST', url: odataUrl },
                'patch': { method: 'PATCH', params: { key: '@key' }, url: odataUrl + '(:key)' },
                'getCategory': { method: 'GET', params: { key: '@key' }, url: odataUrl + '(:key)' },
                'deleteCategory': { method: 'DELETE', params: { key: '@key' }, url: odataUrl + '(:key)' },
                'addCategory': { method: 'POST', url: odataUrl }
            });
    }
})();