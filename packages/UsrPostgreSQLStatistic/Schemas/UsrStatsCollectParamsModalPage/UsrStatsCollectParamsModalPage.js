define("UsrStatsCollectParamsModalPage", /**SCHEMA_DEPS*/[  ]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "remove",
				"name": "PageTitle"
			},
			{
				"operation": "merge",
				"name": "MainContainer",
				"values": {
					"alignItems": "stretch"
				}
			},
			{
				"operation": "merge",
				"name": "SaveButton",
				"values": {
					"clicked": {
						"request": "crt.SaveRecordRequest",
						"params": {
							"showSuccessMessage": true,
							"messageTextAfterCompletion": "#ResourceString(SaveButton_clicked_params_messageTextAfterCompletion)#"
						}
					},
					"color": "accent",
					"caption": "#ResourceString(SaveButton_caption)#"
				}
			},
			{
				"operation": "insert",
				"name": "Label_HeaderCaption",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_HeaderCaption_caption)#)#",
					"labelType": "headline-2",
					"labelThickness": "semibold",
					"labelEllipsis": false,
					"labelColor": "#1271f4e6",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "TitleContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_StatisticsCollectParameters",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 1,
						"rowSpan": 1
					},
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ComboBox_UsrStatisticsCollectType",
				"values": {
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.UsrStatsCollectParamsDS_UsrStatisticsCollectType_xdsz56e",
					"ariaLabel": "",
					"isAddAllowed": true,
					"showValueAsLink": false,
					"labelPosition": "above",
					"controlActions": [],
					"listActions": [],
					"tooltip": "",
					"control": "$UsrStatsCollectParamsDS_UsrStatisticsCollectType_xdsz56e",
					"visible": true,
					"readonly": false,
					"placeholder": "",
					"valueDetails": null
				},
				"parentName": "FlexContainer_StatisticsCollectParameters",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DateTimePicker_UsrStatsCollectStartDateTime",
				"values": {
					"type": "crt.DateTimePicker",
					"label": "$Resources.Strings.UsrStatsCollectParamsDS_UsrStatsCollectStartDateTime_snqt7jd",
					"placeholder": "",
					"readonly": false,
					"labelPosition": "above",
					"tooltip": "",
					"control": "$UsrStatsCollectParamsDS_UsrStatsCollectStartDateTime_snqt7jd",
					"pickerType": "datetime",
					"visible": false
				},
				"parentName": "FlexContainer_StatisticsCollectParameters",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "DateTimePicker_UsrStatsCollectEndDateTime",
				"values": {
					"type": "crt.DateTimePicker",
					"label": "$Resources.Strings.UsrStatsCollectParamsDS_UsrStatsCollectEndDateTime_vbg46ot",
					"placeholder": "",
					"readonly": false,
					"labelPosition": "above",
					"tooltip": "",
					"control": "$UsrStatsCollectParamsDS_UsrStatsCollectEndDateTime_vbg46ot",
					"pickerType": "datetime",
					"visible": false
				},
				"parentName": "FlexContainer_StatisticsCollectParameters",
				"propertyName": "items",
				"index": 2
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [
					"attributes"
				],
				"values": {
					"UsrStatsCollectParamsDS_UsrStatisticsCollectType_xdsz56e": {
						"modelConfig": {
							"path": "UsrStatsCollectParamsDS.UsrStatisticsCollectType"
						}
					},
					"UsrStatsCollectParamsDS_UsrStatisticsCollectType_xdsz56e_List": {
						"isCollection": true,
						"modelConfig": {
							"sortingConfig": {
								"default": [
									{
										"columnName": "Name",
										"direction": "asc"
									}
								]
							}
						}
					},
					"UsrStatsCollectParamsDS_UsrStatsCollectStartDateTime_snqt7jd": {
						"modelConfig": {
							"path": "UsrStatsCollectParamsDS.UsrStatsCollectStartDateTime"
						}
					},
					"UsrStatsCollectParamsDS_UsrStatsCollectEndDateTime_vbg46ot": {
						"modelConfig": {
							"path": "UsrStatsCollectParamsDS.UsrStatsCollectEndDateTime"
						}
					}
				}
			},
			{
				"operation": "merge",
				"path": [
					"attributes",
					"HeaderCaption"
				],
				"values": {
					"modelConfig": {}
				}
			}
		]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [],
				"values": {
					"dataSources": {
						"UsrStatsCollectParamsDS": {
							"type": "crt.EntityDataSource",
							"scope": "page",
							"config": {
								"entitySchemaName": "UsrStatsCollectParams",
								"loadParameters": {
									"options": {
										"pagingConfig": {
											"rowCount": 1,
											"rowsOffset": -1
										},
										"sortingConfig": {
											"columns": []
										}
									}
								},
								"allowCopyingRecords": false
							}
						}
					},
					"primaryDataSourceName": "UsrStatsCollectParamsDS"
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/ [
      {
        request: "crt.CanDiscardUnsavedDataRequest",
        handler: async (request, next) => {
          return true;
        },
      },
    ] /**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/ {} /**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/ {} /**SCHEMA_VALIDATORS*/
	};
});