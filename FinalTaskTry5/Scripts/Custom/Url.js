let itemid;
function cop(id) {
    itemid = String(id);
}
$(document).click(function () {
    var url = document.location.protocol + "//" + document.location.host + "/file/" + itemid;
    new Clipboard('.copy_link', { text: function () { return url; } });
});