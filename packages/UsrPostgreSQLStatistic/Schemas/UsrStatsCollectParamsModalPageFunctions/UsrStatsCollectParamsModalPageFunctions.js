define("UsrStatsCollectParamsModalPageFunctions", [], function () {
  return {
    clearStartDateTime: async function (context) {
      context.UsrStatsCollectParamsDS_UsrStatsCollectStartDateTime_snqt7jd =
        null;
    },

    clearStartEndDateTimes: async function (context) {
      await this.clearStartDateTime(context);
      context.UsrStatsCollectParamsDS_UsrStatsCollectEndDateTime_vbg46ot = null;
    },

    checkStartDateTimeLessThanEndDateTime: async function (context) {
      const startDateTime =
        await context.UsrStatsCollectParamsDS_UsrStatsCollectStartDateTime_snqt7jd;
      const endDateTime =
        await context.UsrStatsCollectParamsDS_UsrStatsCollectEndDateTime_vbg46ot;
      if (startDateTime > endDateTime) {
        await context.executeRequest({
          type: "crt.NotificationRequest",
          $context: context,
          message: "Start date/time must be earlier than end date/time",
        });
      }
    },
  };
});
