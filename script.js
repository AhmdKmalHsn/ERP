function addRow(dom, newRow) {
    let rowCount = $(dom + ' tbody tr').length++;
    $(`${dom} tbody`).append(newRow);
}

function remove(dom, e) {
    $(e).closest('tr').remove();
}

// Function to convert form to JSON
function formToJson(dom) {
    let header = $(`${dom} [name]:not(table [name])`);
    let footer = $(`${dom} table`);
    let formData = {};

    // Handle non-table inputs (header)
    for (let i = 0; i < header.length; i++) {
        let input = header.eq(i);
        let name = input.attr('name');
        let type = input.attr('type');
        if (type === 'checkbox') {
            formData[name] = input.prop('checked');
        } else if (type === 'radio') {
            if (input.prop('checked')) {
                formData[name] = input.val();
            }
        } else {
            if (input.val()) formData[name] = input.val();
        }
    }

    // Handle table inputs (footer)
    for (let i = 0; i < footer.length; i++) {
        let tableName = footer.eq(i).attr('data-table-name');
        let rows = $(`[data-table-name=${tableName}] tbody tr`);
        let rowsData = [];
        for (let j = 0; j < rows.length; j++) {
            let cells = rows.eq(j).find('td [name]');
            let rowDataObj = {};
            for (let k = 0; k < cells.length; k++) {
                let cell = cells.eq(k);
                let cellName = cell.attr("name");
                let cellType = cell.attr('type');
                if (cellType === 'checkbox') {
                    rowDataObj[cellName] = cell.prop('checked');
                } else if (cellType === 'radio') {
                    if (cell.prop('checked')) {
                        rowDataObj[cellName] = cell.val();
                    }
                } else {
                    rowDataObj[cellName] = cell.val();
                }
            }
            rowsData.push(rowDataObj);
        }
        formData[tableName] = rowsData;
    }


    console.log(formData);
}
