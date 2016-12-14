﻿debugger;
    var orderItems = [];
    //Add button click function
    $('#add').click(function () {
        //Check validation of order item
        debugger;
        var isValidItem = true;
        if ($('#ingredientsName').val().trim() == '') {
            isValidItem = false;
            $('#ingredientsName').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#ingredientsName').siblings('span.error').css('visibility', 'hidden');
        }

        if (!($('#quantity').val().trim() != '' && !isNaN($('#quantity').val().trim()))) {
            isValidItem = false;
            $('#quantity').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#quantity').siblings('span.error').css('visibility', 'hidden');
        }

        //Add item to list if valid
        if (isValidItem) {
            orderItems.push({
                IngredientsName: $('#ingredientsName').val().trim(),

                Quantity: parseInt($('#quantity').val().trim()),
            });
            //Clear fields
            $('#ingredientsName').val('').focus();
            $('#quantity').val('');

        }
        //populate order items
        GeneratedItemsTable();

    });
//Save button click function
    debugger;
    $('#submit').click(function () {
        //validation of order
        var isAllValid = true;
        //if (orderItems.length == 0) {
        //    $('#orderItems').html('<span style="color:red;">Please add order items</span>');
        //    isAllValid = false;
        //}

        //if ($('#recipeName').val().trim() == '') {
        //    $('#recipeName').siblings('span.error').css('visibility', 'visible');
        //    isAllValid = false;
        //}
        //else {
        //    $('#recipeName').siblings('span.error').css('visibility', 'hidden');
        //}



        //Save if valid
        debugger;
        if (isAllValid) {
            debugger;
            var data = {
                RecipeName: $('#Name').val().trim(),
                Description: $('#Description').val().trim(),
                Done: $('#Done').val().trim(),
                Favorites: $('#Favourites').val().trim(),
                Ingredient: orderItems
            }

            $(this).val('Please wait...');

            $.ajax({
                url: '/Recipes/SaveOrder',
                type: "POST",
                data: JSON.stringify(data),
                dataType: "JSON",
                contentType: "application/json",
                success: function (d) {
                    //check is successfully save to database
                    if (d.status == true) {
                        //will send status from server side
                        alert('Successfully done.');
                        //clear form
                        orderItems = [];
                        $('#recipeName').val('');
                        $('#orderItems').empty();
                    }
                    else {
                        alert('Failed');
                    }
                    $('#submit').val('Save');
                },
                error: function (err) {
                    alert('Error. Please try again.');
                    $('#submit').val('Save');
                }
            });
        }

    });
    //function for show added items in table
    function GeneratedItemsTable() {
        debugger;
        if (orderItems.length > 0) {
            var $table = $('<table/>');
            $table.append('<thead><tr><th>Item</th><th>Quantity</th><th></th></tr></thead>');
            var $tbody = $('<tbody/>');
            $.each(orderItems, function (i, val) {
                var $row = $('<tr/>');
                $row.append($('<td/>').html(val.IngredientsName));
                $row.append($('<td/>').html(val.Quantity));
                var $remove = $('<a href="#">Remove</a>');
                $remove.click(function (e) {
                    e.preventDefault();
                    orderItems.splice(i, 1);
                    GeneratedItemsTable();
                });
                $row.append($('<td/>').html($remove));
                $tbody.append($row);
            });
            console.log("current", orderItems);
            $table.append($tbody);
            $('#orderItems').html($table);
        }
        else {
            $('#orderItems').html('');
        }
    }