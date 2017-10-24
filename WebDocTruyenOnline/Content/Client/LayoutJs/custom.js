function tinhdiem(diem) {
    var value = document.getElementById('cate_rating_check').value;
    if (value == 1) {
        return false;

    }

    var cate_id = document.getElementById('cate_rating_id').value;
    jQuery.ajax({
        url: WP_CATE_RATING_HOME + "/wp-admin/admin-ajax.php",

        data: {
            'action': 'insertdiem',
            'idcate': cate_id,
            'diem': diem

        },
        success: function (data) {



            if (data == '0') {
                alert('Lá»—i khi Ä‘Ã¡nh giÃ¡. Vui lÃ²ng liÃªn há»‡ ban quáº£n trá»‹!');
            }
            else {
                //alert(data['soluong']);
                //alert(data);
                var result = eval(data);
                document.getElementById('wp_cate_rating_vote').innerHTML = "Sá»‘ lÆ°á»£ng Ä‘Ã¡nh giÃ¡: " + result[0];
                document.getElementById('wp_cate_rating_avg').innerHTML = result[1];
                document.getElementById('cate_rating_tb').value = result[1];
                document.getElementById('cate_rating_check').value = '1';

                var diem = document.getElementById('cate_rating_tb').value;
                for (var i = 1; i <= 10; i++) {
                    if (i > diem) {
                        var half = Math.abs(diemtb - i);
                        if (half > 0 & half < 1) {
                            jQuery('.wp_cate_rating_hover_' + i).attr('src', WP_CATE_RATING_HOME + "/wp-content/plugins/wp-caterating/images/stars/star_25_half.png");
                        }
                        else {
                            jQuery('.wp_cate_rating_hover_' + i).attr('src', WP_CATE_RATING_HOME + "/wp-content/plugins/wp-caterating/images/stars/star_25_off.png");
                        }
                    }
                    else {
                        jQuery('.wp_cate_rating_hover_' + i).attr('src', WP_CATE_RATING_HOME + "/wp-content/plugins/wp-caterating/images/stars/star_25.png");

                    }


                };


            }






        },
        error: function (errorThrown) {
            console.log(errorThrown);
            alert("Loi" + errorThrown);
        }
    });

}
function layidcate() {
    var id = document.getElementById('cate_rating_id').value;
    return id;
}
function overdiem(diem) {
    var value = document.getElementById('cate_rating_check').value;
    if (value == 1) {
        return false;

    }


    document.getElementById('wp-cate-rating-title').innerHTML = "(" + jQuery('.wp_cate_rating_hover_' + diem).attr('title') + ")";


    for (var i = 1; i <= 10; i++) {
        if (i > diem) {
            jQuery('.wp_cate_rating_hover_' + i).attr('src', WP_CATE_RATING_HOME + "/wp-content/plugins/wp-caterating/images/stars/star_25_off.png");

        }
        else {
            jQuery('.wp_cate_rating_hover_' + i).attr('src', WP_CATE_RATING_HOME + "/wp-content/plugins/wp-caterating/images/stars/star_25.png");

        }



    };



}
function outdiem() {
    var value = document.getElementById('cate_rating_check').value;
    if (value == 1) {
        return false;

    }

    var diemtb = document.getElementById('cate_rating_tb').value;


    for (var i = 1; i <= 10; i++) {
        if (i <= diemtb) {
            jQuery('.wp_cate_rating_hover_' + i).attr('src', WP_CATE_RATING_HOME + "/wp-content/plugins/wp-caterating/images/stars/star_25.png");

        }
        else {
            var half = Math.abs(diemtb - i);
            if (half > 0 & half < 1) {
                jQuery('.wp_cate_rating_hover_' + i).attr('src', WP_CATE_RATING_HOME + "/wp-content/plugins/wp-caterating/images/stars/star_25_half.png");
            }
            else {
                jQuery('.wp_cate_rating_hover_' + i).attr('src', WP_CATE_RATING_HOME + "/wp-content/plugins/wp-caterating/images/stars/star_25_off.png");
            }


        }
    }

    document.getElementById('wp-cate-rating-title').innerHTML = "";




}
