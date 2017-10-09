/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';

    config.filebrowserBrowseUrl = '/Content/Admin/plugin/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/Content/Admin/plugin/ckfinder/ckfinder.html?type=Images';
    config.filebrowserFlashBrowseUrl = '/Content/Admin/plugin/ckfinder/ckfinder.html?type=Flash';
    config.filebrowserUploadUrl = '/Content/Admin/plugin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Data'
    config.filebrowserFlashUploadUrl = '/Content/Admin/plugin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

    CKFinder.setupCKEditor(null, '/Content/Admin/plugin/ckfinder/');
};
