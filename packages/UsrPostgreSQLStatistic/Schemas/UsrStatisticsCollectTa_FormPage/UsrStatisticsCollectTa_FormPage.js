define("UsrStatisticsCollectTa_FormPage", /**SCHEMA_DEPS*/["css!UsrStatisticsCollectTa_FormPageCSS"]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "Tabs",
				"values": {
					"styleType": "default",
					"mode": "tab",
					"bodyBackgroundColor": "primary-contrast-500",
					"selectedTabTitleColor": "auto",
					"tabTitleColor": "auto",
					"underlineSelectedTabColor": "auto",
					"headerBackgroundColor": "auto",
					"allowToggleClose": true
				}
			},
			{
				"operation": "merge",
				"name": "GeneralInfoTab",
				"values": {
					"iconPosition": "only-text",
					"visible": true
				}
			},
			{
				"operation": "remove",
				"name": "GeneralInfoTabContainer"
			},
			{
				"operation": "merge",
				"name": "Feed",
				"values": {
					"dataSourceName": "PDS",
					"entitySchemaName": "UsrStatisticsCollectTa"
				}
			},
			{
				"operation": "merge",
				"name": "AttachmentList",
				"values": {
					"columns": [
						{
							"id": "044a0b6f-ffcd-485a-9e30-266dba13cea2",
							"code": "AttachmentListDS_Name",
							"caption": "#ResourceString(AttachmentListDS_Name)#",
							"dataValueType": 28,
							"width": 200
						}
					]
				}
			},
			{
				"operation": "insert",
				"name": "GridContainer_StatisticsCollectTaskStatus",
				"values": {
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"items": [],
					"fitContent": true,
					"padding": {
						"top": "medium",
						"bottom": "medium",
						"right": "medium",
						"left": "medium"
					},
					"color": "primary",
					"borderRadius": "medium",
					"visible": true,
					"alignItems": "stretch"
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_ltlmi90",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 1,
						"rowSpan": 1
					},
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true
				},
				"parentName": "GridContainer_StatisticsCollectTaskStatus",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_StatisticsCollectTaskStatus",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_StatisticsCollectTaskStatus_caption)#)#",
					"labelType": "headline-2",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "FlexContainer_ltlmi90",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "EntityStageProgressBar_StatisticsCollectStatus",
				"values": {
					"type": "crt.EntityStageProgressBar",
					"saveOnChange": false,
					"askUserToChangeSchema": true,
					"entityName": "UsrStatisticsCollectTa",
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 2,
						"rowSpan": 1
					}
				},
				"parentName": "GridContainer_StatisticsCollectTaskStatus",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "UsrName",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.Input",
					"label": "$Resources.Strings.UsrName",
					"control": "$UsrName",
					"labelPosition": "auto"
				},
				"parentName": "SideAreaProfileContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridContainer_czrsrcz",
				"values": {
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"items": [],
					"fitContent": true,
					"padding": {
						"top": "medium",
						"bottom": "medium",
						"right": "medium",
						"left": "medium"
					},
					"color": "primary",
					"borderRadius": "medium",
					"visible": true,
					"alignItems": "stretch"
				},
				"parentName": "SideContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Label_TaskParameters",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 1,
						"rowSpan": 1
					},
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_TaskParameters_caption)#)#",
					"labelType": "headline-1",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "GridContainer_czrsrcz",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_TaskParameters",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 2,
						"rowSpan": 1
					},
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true
				},
				"parentName": "GridContainer_czrsrcz",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ComboBox_UsrStatisticsCollectType",
				"values": {
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.UsrStatsCollectParamsDS_UsrStatisticsCollectType_ivi59zu",
					"ariaLabel": "",
					"isAddAllowed": true,
					"showValueAsLink": true,
					"labelPosition": "auto",
					"controlActions": [],
					"listActions": [],
					"tooltip": "",
					"control": "$UsrStatsCollectParamsDS_UsrStatisticsCollectType_ivi59zu",
					"readonly": true
				},
				"parentName": "FlexContainer_TaskParameters",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "addRecord_bnvub0l",
				"values": {
					"code": "addRecord",
					"type": "crt.ComboboxSearchTextAction",
					"icon": "combobox-add-new",
					"caption": "#ResourceString(addRecord_bnvub0l_caption)#",
					"clicked": {
						"request": "crt.CreateRecordFromLookupRequest",
						"params": {}
					}
				},
				"parentName": "ComboBox_UsrStatisticsCollectType",
				"propertyName": "listActions",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DateTimePicker_UsrStatsCollectStartDateTime",
				"values": {
					"type": "crt.DateTimePicker",
					"label": "$Resources.Strings.UsrStatsCollectParamsDS_UsrStatsCollectStartDateTime_ibfi93x",
					"placeholder": "",
					"readonly": true,
					"labelPosition": "auto",
					"tooltip": "",
					"pickerType": "datetime",
					"control": "$UsrStatsCollectParamsDS_UsrStatsCollectStartDateTime_ibfi93x",
					"visible": false
				},
				"parentName": "FlexContainer_TaskParameters",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "DateTimePicker_UsrStatsCollectEndDateTime",
				"values": {
					"type": "crt.DateTimePicker",
					"label": "$Resources.Strings.UsrStatsCollectParamsDS_UsrStatsCollectEndDateTime_by68p05",
					"placeholder": "",
					"readonly": true,
					"labelPosition": "auto",
					"tooltip": "",
					"pickerType": "datetime",
					"control": "$UsrStatsCollectParamsDS_UsrStatsCollectEndDateTime_by68p05",
					"visible": false
				},
				"parentName": "FlexContainer_TaskParameters",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ComboBox_BusinessProcessInstance",
				"values": {
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.PDS_UsrBusinessProcessInstance_9kodrxa",
					"ariaLabel": "",
					"isAddAllowed": true,
					"showValueAsLink": true,
					"labelPosition": "auto",
					"controlActions": [],
					"listActions": [],
					"tooltip": "",
					"control": "$PDS_UsrBusinessProcessInstance_9kodrxa",
					"visible": true,
					"readonly": true,
					"placeholder": "",
					"valueDetails": null
				},
				"parentName": "FlexContainer_TaskParameters",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "GridContainer_ErrorDescription",
				"values": {
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"items": [],
					"fitContent": true,
					"padding": {
						"top": "medium",
						"bottom": "medium",
						"right": "medium",
						"left": "medium"
					},
					"color": "primary",
					"borderRadius": "medium",
					"visible": false,
					"alignItems": "stretch"
				},
				"parentName": "SideContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "FlexContainer_z11jqs4",
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
				"parentName": "GridContainer_ErrorDescription",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_ErrorDetails",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_ErrorDetails_caption)#)#",
					"labelType": "headline-1",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "FlexContainer_z11jqs4",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Input_UsrErrorDescription",
				"values": {
					"type": "crt.Input",
					"label": "$Resources.Strings.PDS_UsrErrorDescription_ewmkm8f",
					"control": "$PDS_UsrErrorDescription_ewmkm8f",
					"placeholder": "",
					"tooltip": "",
					"readonly": true,
					"multiline": true,
					"labelPosition": "auto",
					"visible": true
				},
				"parentName": "FlexContainer_z11jqs4",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridContainer_9j64h0l",
				"values": {
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch"
				},
				"parentName": "GeneralInfoTab",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_wplavud",
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
				"parentName": "GridContainer_9j64h0l",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_StatisticsCollectTaskIsInProgress",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_StatisticsCollectTaskIsInProgress_caption)#)#",
					"labelType": "large-4",
					"labelThickness": "bold",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": false
				},
				"parentName": "FlexContainer_wplavud",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_ActionCompletedWithError",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_ActionCompletedWithError_caption)#)#",
					"labelType": "large-4",
					"labelThickness": "bold",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": false
				},
				"parentName": "FlexContainer_wplavud",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ExpansionPanel_To20HeaviestRequests",
				"values": {
					"type": "crt.ExpansionPanel",
					"tools": [],
					"items": [],
					"title": "#ResourceString(ExpansionPanel_To20HeaviestRequests_title)#",
					"toggleType": "default",
					"togglePosition": "before",
					"expanded": true,
					"labelColor": "auto",
					"fullWidthHeader": false,
					"titleWidth": 20,
					"padding": {
						"top": "small",
						"bottom": "small",
						"left": "none",
						"right": "none"
					},
					"fitContent": true,
					"visible": false,
					"alignItems": "stretch"
				},
				"parentName": "FlexContainer_wplavud",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "GridContainer_n9mnl0r",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 24px)",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": 0
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": []
				},
				"parentName": "ExpansionPanel_To20HeaviestRequests",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_yqjp9fb",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"gap": "none",
					"alignItems": "center",
					"items": [],
					"layoutConfig": {
						"colSpan": 1,
						"column": 1,
						"row": 1,
						"rowSpan": 1
					}
				},
				"parentName": "GridContainer_n9mnl0r",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetailAddBtn_27m8w50",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(GridDetailAddBtn_27m8w50_caption)#",
					"icon": "add-button-icon",
					"iconPosition": "only-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.CreateRecordRequest",
						"params": {
							"entityName": "UsrPgStatStatementsTotalExecTime"
						}
					}
				},
				"parentName": "FlexContainer_yqjp9fb",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetailRefreshBtn_1spm0bj",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(GridDetailRefreshBtn_1spm0bj_caption)#",
					"icon": "reload-icon",
					"iconPosition": "only-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.LoadDataRequest",
						"params": {
							"config": {
								"loadType": "reload"
							},
							"dataSourceName": "GridDetail_nlnib64DS"
						}
					}
				},
				"parentName": "FlexContainer_yqjp9fb",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridDetailSettingsBtn_qtby39k",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(GridDetailSettingsBtn_qtby39k_caption)#",
					"icon": "actions-button-icon",
					"iconPosition": "only-icon",
					"color": "default",
					"size": "medium",
					"clickMode": "menu",
					"menuItems": []
				},
				"parentName": "FlexContainer_yqjp9fb",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "GridDetailExportDataBtn_7c774b6",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(GridDetailExportDataBtn_7c774b6_caption)#",
					"icon": "export-button-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.ExportDataGridToExcelRequest",
						"params": {
							"viewName": "GridDetail_pg_stat_statements_ordered_total_exec_time"
						}
					}
				},
				"parentName": "GridDetailSettingsBtn_qtby39k",
				"propertyName": "menuItems",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetailImportDataBtn_bqf8nn4",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(GridDetailImportDataBtn_bqf8nn4_caption)#",
					"icon": "import-button-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.ImportDataRequest",
						"params": {
							"entitySchemaName": "UsrPgStatStatementsTotalExecTime"
						}
					}
				},
				"parentName": "GridDetailSettingsBtn_qtby39k",
				"propertyName": "menuItems",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridDetailSearchFilter_750a5nz",
				"values": {
					"type": "crt.SearchFilter",
					"placeholder": "#ResourceString(GridDetailSearchFilter_750a5nz_placeholder)#",
					"iconOnly": true,
					"_filterOptions": {
						"expose": [
							{
								"attribute": "GridDetailSearchFilter_750a5nz_GridDetail_nlnib64",
								"converters": [
									{
										"converter": "crt.SearchFilterAttributeConverter",
										"args": [
											"GridDetail_nlnib64"
										]
									}
								]
							}
						],
						"from": [
							"GridDetailSearchFilter_750a5nz_SearchValue",
							"GridDetailSearchFilter_750a5nz_FilteredColumnsGroups"
						]
					}
				},
				"parentName": "FlexContainer_yqjp9fb",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "GridContainer_z60robt",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 32px)",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": 0
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": []
				},
				"parentName": "ExpansionPanel_To20HeaviestRequests",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetail_pg_stat_statements_ordered_total_exec_time",
				"values": {
					"type": "crt.DataGrid",
					"layoutConfig": {
						"colSpan": 2,
						"column": 1,
						"row": 1,
						"rowSpan": 11
					},
					"features": {
						"rows": {
							"selection": false,
							"numeration": true
						},
						"editable": {
							"enable": false,
							"itemsCreation": false,
							"floatingEditPanel": false
						},
						"columns": {
							"sorting": false,
							"dragAndDrop": true
						}
					},
					"items": "$GridDetail_nlnib64",
					"activeRow": "$GridDetail_nlnib64_ActiveRow",
					"selectionState": "$GridDetail_nlnib64_SelectionState",
					"_selectionOptions": {
						"attribute": "GridDetail_nlnib64_SelectionState"
					},
					"primaryColumnName": "GridDetail_nlnib64DS_Id",
					"columns": [
						{
							"id": "3a804397-bddf-d424-e765-6a847877349c",
							"code": "GridDetail_nlnib64DS_CreatedOn",
							"caption": "#ResourceString(GridDetail_nlnib64DS_CreatedOn)#",
							"dataValueType": 7
						},
						{
							"id": "1b017084-45c8-412a-7d1d-210852a9de18",
							"code": "GridDetail_nlnib64DS_UsrDatabaseName",
							"caption": "#ResourceString(GridDetail_nlnib64DS_UsrDatabaseName)#",
							"dataValueType": 28
						},
						{
							"id": "4e9e382d-dbe4-6f07-b901-9f552c419280",
							"code": "GridDetail_nlnib64DS_UsrTotalExecTime",
							"caption": "#ResourceString(GridDetail_nlnib64DS_UsrTotalExecTime)#",
							"dataValueType": 32
						},
						{
							"id": "53420acd-0541-de74-7575-55ee7be40747",
							"code": "GridDetail_nlnib64DS_UsrNumberOfCalls",
							"caption": "#ResourceString(GridDetail_nlnib64DS_UsrNumberOfCalls)#",
							"dataValueType": 28
						},
						{
							"id": "efe24876-ccd1-82cb-bb72-94e8f950f415",
							"code": "GridDetail_nlnib64DS_UsrMeanExecTime",
							"caption": "#ResourceString(GridDetail_nlnib64DS_UsrMeanExecTime)#",
							"dataValueType": 32
						},
						{
							"id": "014b10c3-c2aa-d5aa-dc9b-33bf08358e5f",
							"code": "GridDetail_nlnib64DS_UsrPercentageCPU",
							"caption": "#ResourceString(GridDetail_nlnib64DS_UsrPercentageCPU)#",
							"dataValueType": 32
						},
						{
							"id": "645d5075-fc91-c3e1-0213-80e56d915bbd",
							"code": "GridDetail_nlnib64DS_UsrShortQuery",
							"caption": "#ResourceString(GridDetail_nlnib64DS_UsrShortQuery)#",
							"dataValueType": 29
						}
					],
					"placeholder": false,
					"bulkActions": [],
					"visible": true,
					"fitContent": true
				},
				"parentName": "GridContainer_z60robt",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetail_nlnib64_AddTagsBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "Add tag",
					"icon": "tag-icon",
					"clicked": {
						"request": "crt.AddTagsInRecordsRequest",
						"params": {
							"dataSourceName": "GridDetail_nlnib64DS",
							"filters": "$GridDetail_nlnib64 | crt.ToCollectionFilters : 'GridDetail_nlnib64' : $GridDetail_nlnib64_SelectionState | crt.SkipIfSelectionEmpty : $GridDetail_nlnib64_SelectionState"
						}
					},
					"items": []
				},
				"parentName": "GridDetail_pg_stat_statements_ordered_total_exec_time",
				"propertyName": "bulkActions",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetail_nlnib64_RemoveTagsBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "Remove tag",
					"icon": "delete-button-icon",
					"clicked": {
						"request": "crt.RemoveTagsInRecordsRequest",
						"params": {
							"dataSourceName": "GridDetail_nlnib64DS",
							"filters": "$GridDetail_nlnib64 | crt.ToCollectionFilters : 'GridDetail_nlnib64' : $GridDetail_nlnib64_SelectionState | crt.SkipIfSelectionEmpty : $GridDetail_nlnib64_SelectionState"
						}
					}
				},
				"parentName": "GridDetail_nlnib64_AddTagsBulkAction",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetail_nlnib64_ExportToExcelBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "Export to Excel",
					"icon": "export-button-icon",
					"clicked": {
						"request": "crt.ExportDataGridToExcelRequest",
						"params": {
							"viewName": "GridDetail_pg_stat_statements_ordered_total_exec_time",
							"filters": "$GridDetail_nlnib64 | crt.ToCollectionFilters : 'GridDetail_nlnib64' : $GridDetail_nlnib64_SelectionState | crt.SkipIfSelectionEmpty : $GridDetail_nlnib64_SelectionState"
						}
					}
				},
				"parentName": "GridDetail_pg_stat_statements_ordered_total_exec_time",
				"propertyName": "bulkActions",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridDetail_nlnib64_MergeBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "Merge",
					"icon": "merge-icon",
					"clicked": {
						"request": "crt.MergeRecordsRequest",
						"params": {
							"dataSourceName": "GridDetail_nlnib64DS",
							"selectionState": "$GridDetail_nlnib64_SelectionState"
						}
					}
				},
				"parentName": "GridDetail_pg_stat_statements_ordered_total_exec_time",
				"propertyName": "bulkActions",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "GridDetail_nlnib64_DeleteBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "Delete",
					"icon": "delete-button-icon",
					"clicked": {
						"request": "crt.DeleteRecordsRequest",
						"params": {
							"dataSourceName": "GridDetail_nlnib64DS",
							"filters": "$GridDetail_nlnib64 | crt.ToCollectionFilters : 'GridDetail_nlnib64' : $GridDetail_nlnib64_SelectionState | crt.SkipIfSelectionEmpty : $GridDetail_nlnib64_SelectionState"
						}
					}
				},
				"parentName": "GridDetail_pg_stat_statements_ordered_total_exec_time",
				"propertyName": "bulkActions",
				"index": 3
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [
					"attributes"
				],
				"values": {
					"UsrName": {
						"modelConfig": {
							"path": "PDS.UsrName"
						}
					},
					"UsrStatsCollectParamsDS_UsrStatisticsCollectType_ivi59zu": {
						"modelConfig": {
							"path": "UsrStatsCollectParamsDS.UsrStatisticsCollectType"
						}
					},
					"UsrStatsCollectParamsDS_UsrStatisticsCollectType_ivi59zu_List": {
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
					"UsrStatsCollectParamsDS_UsrStatsCollectStartDateTime_ibfi93x": {
						"modelConfig": {
							"path": "UsrStatsCollectParamsDS.UsrStatsCollectStartDateTime"
						}
					},
					"UsrStatsCollectParamsDS_UsrStatsCollectEndDateTime_by68p05": {
						"modelConfig": {
							"path": "UsrStatsCollectParamsDS.UsrStatsCollectEndDateTime"
						}
					},
					"PDS_UsrBusinessProcessInstance_9kodrxa": {
						"modelConfig": {
							"path": "PDS.UsrBusinessProcessInstance"
						}
					},
					"PDS_UsrBusinessProcessInstance_9kodrxa_List": {
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
					"PDS_UsrErrorDescription_ewmkm8f": {
						"modelConfig": {
							"path": "PDS.UsrErrorDescription"
						}
					},
					"GridDetail_nlnib64": {
						"isCollection": true,
						"modelConfig": {
							"path": "GridDetail_nlnib64DS",
							"filterAttributes": [
								{
									"name": "GridDetailSearchFilter_750a5nz_GridDetail_nlnib64",
									"loadOnChange": true
								},
								{
									"loadOnChange": true,
									"name": "GridDetail_nlnib64_PredefinedFilter"
								}
							],
							"sortingConfig": {
								"default": [
									{
										"direction": "desc",
										"columnName": "UsrTotalExecTime"
									}
								]
							},
							"pagingConfig": {
								"rowCount": 30,
								"rowsLimit": 20
							}
						},
						"viewModelConfig": {
							"attributes": {
								"GridDetail_nlnib64DS_CreatedOn": {
									"modelConfig": {
										"path": "GridDetail_nlnib64DS.CreatedOn"
									}
								},
								"GridDetail_nlnib64DS_UsrDatabaseName": {
									"modelConfig": {
										"path": "GridDetail_nlnib64DS.UsrDatabaseName"
									}
								},
								"GridDetail_nlnib64DS_UsrTotalExecTime": {
									"modelConfig": {
										"path": "GridDetail_nlnib64DS.UsrTotalExecTime"
									}
								},
								"GridDetail_nlnib64DS_UsrNumberOfCalls": {
									"modelConfig": {
										"path": "GridDetail_nlnib64DS.UsrNumberOfCalls"
									}
								},
								"GridDetail_nlnib64DS_UsrMeanExecTime": {
									"modelConfig": {
										"path": "GridDetail_nlnib64DS.UsrMeanExecTime"
									}
								},
								"GridDetail_nlnib64DS_UsrPercentageCPU": {
									"modelConfig": {
										"path": "GridDetail_nlnib64DS.UsrPercentageCPU"
									}
								},
								"GridDetail_nlnib64DS_UsrShortQuery": {
									"modelConfig": {
										"path": "GridDetail_nlnib64DS.UsrShortQuery"
									}
								},
								"GridDetail_nlnib64DS_Id": {
									"modelConfig": {
										"path": "GridDetail_nlnib64DS.Id"
									}
								}
							}
						}
					},
					"GridDetail_nlnib64_PredefinedFilter": {
						"value": null
					}
				}
			},
			{
				"operation": "merge",
				"path": [
					"attributes",
					"Id",
					"modelConfig"
				],
				"values": {
					"path": "PDS.Id"
				}
			}
		]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [],
				"values": {
					"primaryDataSourceName": "PDS",
					"loadingConfig": {},
					"dependencies": {
						"UsrStatsCollectParamsDS": [
							{
								"attributePath": "UsrStatisticsCollectTask",
								"relationPath": "PDS.Id"
							}
						],
						"GridDetail_nlnib64DS": [
							{
								"attributePath": "UsrStatisticsCollectTask",
								"relationPath": "PDS.Id"
							}
						]
					}
				}
			},
			{
				"operation": "merge",
				"path": [
					"dataSources"
				],
				"values": {
					"PDS": {
						"type": "crt.EntityDataSource",
						"config": {
							"entitySchemaName": "UsrStatisticsCollectTa"
						},
						"scope": "page"
					},
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
										"columns": [
											{
												"columnName": "CreatedOn",
												"direction": "desc"
											}
										]
									}
								}
							},
							"allowCopyingRecords": false
						}
					},
					"GridDetail_nlnib64DS": {
						"type": "crt.EntityDataSource",
						"scope": "viewElement",
						"config": {
							"entitySchemaName": "UsrPgStatStatementsTotalExecTime",
							"attributes": {
								"CreatedOn": {
									"path": "CreatedOn"
								},
								"UsrDatabaseName": {
									"path": "UsrDatabaseName"
								},
								"UsrTotalExecTime": {
									"path": "UsrTotalExecTime"
								},
								"UsrNumberOfCalls": {
									"path": "UsrNumberOfCalls"
								},
								"UsrMeanExecTime": {
									"path": "UsrMeanExecTime"
								},
								"UsrPercentageCPU": {
									"path": "UsrPercentageCPU"
								},
								"UsrShortQuery": {
									"path": "UsrShortQuery"
								}
							}
						}
					}
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});