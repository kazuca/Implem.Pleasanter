﻿using Implem.Libraries.Utilities;
using Implem.Pleasanter.Interfaces;
using Implem.Pleasanter.Libraries.Html;
using Implem.Pleasanter.Libraries.HtmlParts;
using Implem.Pleasanter.Libraries.Requests;
using Implem.Pleasanter.Libraries.Server;
using Implem.Pleasanter.Libraries.Settings;
using System;
using System.Linq;
using static Implem.Pleasanter.Libraries.ServerScripts.ServerScriptModel;
namespace Implem.Pleasanter.Libraries.Extensions
{
    public static class TdExtensions
    {
        public static HtmlBuilder Td(
            this HtmlBuilder hb,
            Context context,
            Column column,
            IConvertable value,
            int? tabIndex,
            ServerScriptModelColumn serverScriptValues = null)
        {
            return column != null && value != null
                ? value.Td(
                    hb: hb,
                    context: context,
                    column: column,
                    tabIndex: tabIndex,
                    serverScriptValues: serverScriptValues)
                : hb.Td(
                    css: column.CellCss(serverScriptValues?.ExtendedCellCss),
                    action: () => hb
                        .Text(string.Empty));
        }

        public static HtmlBuilder Td(
            this HtmlBuilder hb,
            Context context,
            Column column,
            TimeZoneInfo value,
            int? tabIndex,
            ServerScriptModelColumn serverScriptValues = null)
        {
            return hb.Td(
                css: column.CellCss(serverScriptValues?.ExtendedCellCss),
                action: () => hb
                    .Text(text: value?.StandardName));
        }

        public static HtmlBuilder Td(
            this HtmlBuilder hb,
            Context context,
            Column column,
            string value,
            int? tabIndex,
            ServerScriptModelColumn serverScriptValues = null)
        {
            if (column.HasChoices())
            {
                var choiceParts = column.ChoiceParts(
                    context: context,
                    selectedValues: value,
                    type: ExportColumn.Types.TextMini);
                return hb.Td(
                    css: column.CellCss(serverScriptValues?.ExtendedCellCss),
                    action: () => hb
                        .Text(text: column.MultipleSelections == true
                            ? choiceParts.Join(", ")
                            : choiceParts.FirstOrDefault()));
            }
            else
            {
                return column.ControlType == "MarkDown"
                    ? hb.Td(
                        css: column.CellCss(serverScriptValues?.ExtendedCellCss),
                        action: () => hb
                            .Div(css: "grid-title-body", action: () => hb
                                .P(css: "body markup", action: () => hb
                                    .Text(text: value))))
                    : hb.Td(
                        css: column.CellCss(serverScriptValues?.ExtendedCellCss),
                        action: () => hb
                            .Text(text: value));
            }
        }

        public static HtmlBuilder Td(
            this HtmlBuilder hb,
            Context context,
            Column column,
            int value,
            int? tabIndex,
            ServerScriptModelColumn serverScriptValues = null)
        {
            return hb.Td(
                css: column.CellCss(serverScriptValues?.ExtendedCellCss),
                action: () => hb
                    .Text(text: value.ToString(column.StringFormat) + column.Unit));
        }

        public static HtmlBuilder Td(
            this HtmlBuilder hb,
            Context context,
            Column column,
            long value,
            int? tabIndex,
            ServerScriptModelColumn serverScriptValues = null)
        {
            return hb.Td(
                css: column.CellCss(serverScriptValues?.ExtendedCellCss),
                action: () => hb
                    .Text(text: value.ToString(column.StringFormat) + column.Unit));
        }

        public static HtmlBuilder Td(
            this HtmlBuilder hb,
            Context context,
            Column column,
            decimal value,
            int? tabIndex,
            ServerScriptModelColumn serverScriptValues = null)
        {
            return hb.Td(
                css: column.CellCss(serverScriptValues?.ExtendedCellCss),
                action: () => hb
                    .Text(text: column.Display(
                        context: context,
                        value: value,
                        unit: true)));
        }

        public static HtmlBuilder Td(
            this HtmlBuilder hb,
            Context context,
            Column column,
            DateTime value,
            int? tabIndex,
            ServerScriptModelColumn serverScriptValues = null)
        {
            return hb.Td(
                css: column.CellCss(serverScriptValues?.ExtendedCellCss),
                action: () => hb
                    .Text(text: column.DisplayGrid(
                        context: context,
                        value: value.ToLocal(context: context))));
        }

        public static HtmlBuilder Td(
            this HtmlBuilder hb,
            Context context,
            Column column,
            bool value,
            int? tabIndex,
            ServerScriptModelColumn serverScriptValues = null)
        {
            return column.HasChoices()
                ? value
                    ? hb.Td(
                        css: column.CellCss(serverScriptValues?.ExtendedCellCss),
                        action: () => hb
                            .Text(text: column.ChoicesText.SplitReturn()._1st()))
                    : hb.Td(
                        css: column.CellCss(serverScriptValues?.ExtendedCellCss),
                        action: () => hb
                            .Text(text: column.ChoicesText.SplitReturn()._2nd()))
                : hb.Td(
                    css: column.CellCss(serverScriptValues?.ExtendedCellCss),
                    action: () => hb
                        .Span(css: "ui-icon ui-icon-circle-check", _using: value));
        }

        public static HtmlBuilder Td(
            this HtmlBuilder hb,
            Context context,
            Column column,
            Enum value,
            int? tabIndex,
            ServerScriptModelColumn serverScriptValues = null)
        {
            return hb.Td(
                css: column.CellCss(serverScriptValues?.ExtendedCellCss),
                action: () => hb
                    .Text(text: value.ToString()));
        }

        public static HtmlBuilder Td(
            this HtmlBuilder hb,
            Context context,
            Column column,
            Action action,
            int? tabIndex,
            ServerScriptModelColumn serverScriptValues = null)
        {
            return hb.Td(
                css: column.CellCss(serverScriptValues?.ExtendedCellCss),
                action: action);
        }
    }
}