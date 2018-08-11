function tabController(data, $scope) {
    var tabsArray = [];
    for (var i = 0; i < data.length; i++) {
        tabsArray.push(
            {
                'title': "Customer ID: " + data[i].CustomerID,
                'content': data[i].CustomerCode + " The data you are seeing here is for the customer with the Custome rCode " + data[i].CustomerCode
            });
    }
    var tabs = tabsArray,
        selected = null,
        previous = null;
    $scope.tabs = tabs;
    $scope.selectedIndex = 0;
    $scope.$watch('selectedIndex', function (current, old) {
        previous = selected;
        selected = tabs[current];
    });
    $scope.addTab = function (title, view) {
        view = view || title + " Content View";
        tabs.push({ title: title, content: view, disabled: false });
    };
    $scope.removeTab = function (tab) {
        var index = tabs.indexOf(tab);
        tabs.splice(index, 1);
    };
}