$(document).ready(loadWasteTypeFilter())
$(document).ready(loadDisposablePlacesTypeFilter())

function loadWasteTypeFilter() {
    $.ajax({
        type: "GET",
        url: window.location.origin + "/api/wastetypes",
        cache: false,
        success: function(data){
            console.log(data);
            fillWasteTypes(data);
        }
    });
}

function fillWasteTypes(vasteTypes) {
    vasteTypes.forEach(element => {
        $('#waste-types').append('<a href="#" class="list-group-item list-group-item-action"><i class="fa fa-fw fa-fire"></i>'
            + element.name +
            '<i class="fa fa-filter"></i></a>');
    });
}


function loadDisposablePlacesTypeFilter() {
    $.ajax({
        type: "GET",
        url: window.location.origin + "/api/disposallocation/types",
        cache: false,
        success: function(data){
            console.log(data);
            fillDisposalLocationTypes(data);
        }
    });
}

function fillDisposalLocationTypes(vasteTypes) {
    vasteTypes.forEach(element => {
        $('#disposal-place-types').append('<a href="#" class="list-group-item list-group-item-action"><i class="fa fa-fw fa-fire"></i>'
            + element.name +
            '<i class="fa fa-filter"></i></a>');
    });
}