function insertTextAtCursor(el, text, offset) {
    var val = el.value, endIndex, range, doc = el.ownerDocument;
    if (typeof el.selectionStart == "number"
        && typeof el.selectionEnd == "number") {
        endIndex = el.selectionEnd;
        el.value = val.slice(0, endIndex) + text + val.slice(endIndex);
        el.selectionStart = el.selectionEnd = endIndex + text.length + (offset ? offset : 0);
    } else if (doc.selection != "undefined" && doc.selection.createRange) {
        el.focus();
        range = doc.selection.createRange();
        range.collapse(false);
        range.text = text;
        range.select();
    }
}


$(document).ready(function(){
    $("#MarkdownEditor").html(`<div class=" m-auto btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
                <div class="btn-group-sm mr-2" role="group" aria-label="First group">
                    <button type="button" onclick="insertTextAtCursor(document.getElementById('markdownText'),'# ');" class="btn btn-secondary">H1</button>
                    <button type="button" onclick="insertTextAtCursor(document.getElementById('markdownText'),'## ');" class="btn btn-secondary">H2</button>
                    <button type="button" onclick="insertTextAtCursor(document.getElementById('markdownText'),'### ');" class="btn btn-secondary">H3</button>
                    <button type="button" onclick="insertTextAtCursor(document.getElementById('markdownText'),'#### ');" class="btn btn-secondary">H4</button>
                </div>

                <div class="btn-group-sm mr-2" role="group" aria-label="Second group">
                    <button type="button" onclick="insertTextAtCursor(document.getElementById('markdownText'),'**text** ');" class="btn btn-secondary"><b>Ж</b></button>

                    <button type="button" onclick="insertTextAtCursor(document.getElementById('markdownText'),'*text*');" class="btn btn-secondary">К</button>

                    <button type="button" onclick="insertTextAtCursor(document.getElementById('markdownText'),'***text***');" class="btn btn-secondary">ЖК</button>
                </div>

                <div class="btn-group-sm mr-2" role="group" aria-label="Second group">
                    <button type="button" onclick="insertTextAtCursor(document.getElementById('markdownText'),'1. text ');" class="btn btn-secondary"><b>1</b></button>

                    <button type="button" onclick="insertTextAtCursor(document.getElementById('markdownText'),'- text');" class="btn btn-secondary">.</button>

                    <button type="button" onclick="insertTextAtCursor(document.getElementById('markdownText'),'* text');" class="btn btn-secondary">-</button>
                </div>

                <div class="btn-group-sm" role="group" aria-label="Third group">
                    <button type="button" onclick="view()" class="btn btn-secondary">View</button>
                </div>
            </div>`)
});

