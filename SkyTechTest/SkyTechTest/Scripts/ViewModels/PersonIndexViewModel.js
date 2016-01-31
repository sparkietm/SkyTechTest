
function PersonIndexViewModel()
{
    var self = this;

    self.loadList= function ()
    {
        $.ajax({
            url: "Person/GetList",
            method: "GET",
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                alert('Got the data');
                self.people(data);
            },
            error: function (request) {
                alert('Something really bad happened')
            }
        });
    }

    self.saveList = function (data) {

        $.ajax({
            url: "Person/SaveList",
            method: "POST",
            data: JSON.stringify(data),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                alert('All good');
            },
            error: function (request) {
                alert('Something really bad happened')    
            }
        });
    }

    self.people = ko.observableArray();

    // With a more elaborate data structure you might map directly from the AJAX returned data - specifying child elements, including or exlcuding observables et..

    // this is actually from the knockout site.
    //var mapping = {
    //    'children': {
    //        create: function (options) {
    //            return new myChildModel(options.data);
    //        }
    //    }
    //}

}


var model = new PersonIndexViewModel();
model.loadList();
ko.applyBindings(model);