<script type="text/javascripts">
    (function (d, s, id) {
                                                            var js, fjs = d.getElementsByTagName(s)[0];
                                                            if (d.getElementById(id)) return;
                                                            js = d.createElement(s); js.id = id;
                                                            js.src = "//connect.facebook.net/vi_VN/sdk.js#xfbml=1&version=v2.5";
                                                            fjs.parentNode.insertBefore(js, fjs);
                                                        }(document, 'script', 'facebook-jssdk'));</script>

    <script src="https://apis.google.com/js/platform.js" async defer>
        {lang: 'vi' }
    </script>

    <script type="text/javascript">
        jQuery(function ($) {
            $('.select-hot-comic').on('change', function (e) {
                var term_id = $(this).val();
                $('.group-hot-comic').html('<div class="loading"><i class="fa fa-spinner fa-pulse"></i></div>');
                $.ajax({
                    type: 'GET',
                    url: 'http://demo6v2.wpair.net/wp-admin/admin-ajax.php',
                    data: {
                        action: 'load_hot_comic',
                        term_id: term_id
                    },
                    beforeSend: function (jqXHR, settings) {

                    },
                    success: function (data, textStatus, jqXHR) {
                        $('.group-hot-comic').html(data);
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        alert(errorThrown);
                    }
                });
            });

        $('.select-new-comic').on('change', function (e) {
                                                                var term_id = $(this).val();
                                                                $('.group-new-comic').html('<div class="loading"><i class="fa fa-spinner fa-pulse"></i></div>');
                                                                $.ajax({
            type: 'GET',
                                                                    url: 'http://demo6v2.wpair.net/wp-admin/admin-ajax.php',
                                                                    data: {
            action: 'load_new_comic',
                                                                        term_id: term_id
                                                                    },
                                                                    beforeSend: function (jqXHR, settings) {
        },
                                                                    success: function (data, textStatus, jqXHR) {
            $('.group-new-comic').html(data);
        },
                                                                    error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
                                                                });
                                                            });
                                                        });
    </script>