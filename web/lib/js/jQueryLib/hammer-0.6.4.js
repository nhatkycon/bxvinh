﻿/*
* Hammer.JS
* version 0.6.4
* author: Eight Media
* https://github.com/EightMedia/hammer.js
* Licensed under the MIT license.
*/
function Hammer(a, b, c) { function y(a) { return a.touches ? a.touches.length : 1 } function z(a) { if (a = a || window.event, w) { for (var e, d = [], f = 0, g = a.touches.length; g > f; f++) e = a.touches[f], d.push({ x: e.pageX, y: e.pageY }); return d } var b = document, c = b.body; return [{ x: a.pageX || a.clientX + (b && b.scrollLeft || c && c.scrollLeft || 0) - (b && b.clientLeft || c && b.clientLeft || 0), y: a.pageY || a.clientY + (b && b.scrollTop || c && c.scrollTop || 0) - (b && b.clientTop || c && b.clientTop || 0)}] } function A(a, b) { return 180 * Math.atan2(b.y - a.y, b.x - a.x) / Math.PI } function B(a, b) { var c = b.x - a.x, d = b.y - a.y; return Math.sqrt(c * c + d * d) } function C(a, b) { if (2 == a.length && 2 == b.length) { var c = B(a[0], a[1]), d = B(b[0], b[1]); return d / c } return 0 } function D(a, b) { if (2 == a.length && 2 == b.length) { var c = A(a[1], a[0]), d = A(b[1], b[0]); return d - c } return 0 } function E(a, b) { b.touches = z(b.originalEvent), b.type = a, M(d["on" + a]) && d["on" + a].call(d, b) } function F(a) { a = a || window.event, a.preventDefault ? (a.preventDefault(), a.stopPropagation()) : (a.returnValue = !1, a.cancelBubble = !0) } function G() { i = {}, k = !1, j = 0, f = 0, g = 0, l = null } function I(c) { function q() { i.start = z(c), n = (new Date).getTime(), j = y(c), k = !0, t = c; var b = a.getBoundingClientRect(), d = a.clientTop || document.body.clientTop || 0, e = a.clientLeft || document.body.clientLeft || 0, f = window.pageYOffset || a.scrollTop || document.body.scrollTop, g = window.pageXOffset || a.scrollLeft || document.body.scrollLeft; r = { top: b.top + f - d, left: b.left + g - e }, s = !0, H.hold(c) } var d; switch (c.type) { case "mousedown": case "touchstart": d = y(c), x = 1 === d, 2 === d && "drag" === l && E("dragend", { originalEvent: c, direction: h, distance: f, angle: g }), q(), b.prevent_default && F(c); break; case "mousemove": case "touchmove": if (d = y(c), !s && 1 === d) return !1; s || 2 !== d || (x = !1, G(), q()), u = c, i.move = z(c), H.transform(c) || H.drag(c); break; case "mouseup": case "mouseout": case "touchcancel": case "touchend": var e = !0; if (s = !1, v = c, H.swipe(c), "drag" == l) E("dragend", { originalEvent: c, direction: h, distance: f, angle: g }); else if ("transform" == l) { var o = i.center.x - i.startCenter.x, p = i.center.y - i.startCenter.y; E("transformend", { originalEvent: c, position: i.center, scale: C(i.start, i.move), rotation: D(i.start, i.move), distance: f, distanceX: o, distanceY: p }), 1 === y(c) && (G(), q(), e = !1) } else x && H.tap(t); m = l, E("release", { originalEvent: c, gesture: l, position: i.move || i.start }), e && G() } } function J(b) { K(a, b.relatedTarget) || I(b) } function K(a, b) { if (!b && window.event && window.event.toElement && (b = window.event.toElement), a === b) return !0; if (b) for (var c = b.parentNode; null !== c; ) { if (c === a) return !0; c = c.parentNode } return !1 } function L(a, b) { var c = {}; if (!b) return a; for (var d in a) c[d] = d in b ? b[d] : a[d]; return c } function M(a) { return "[object Function]" == Object.prototype.toString.call(a) } function N(a, b, c) { b = b.split(" "); for (var d = 0, e = b.length; e > d; d++) a.addEventListener ? a.addEventListener(b[d], c, !1) : document.attachEvent && a.attachEvent("on" + b[d], c) } function O(a, b, c) { b = b.split(" "); for (var d = 0, e = b.length; e > d; d++) a.removeEventListener ? a.removeEventListener(b[d], c, !1) : document.detachEvent && a.detachEvent("on" + b[d], c) } var d = this, e = L({ prevent_default: !1, css_hacks: !0, swipe: !0, swipe_time: 200, swipe_min_distance: 20, drag: !0, drag_vertical: !0, drag_horizontal: !0, drag_min_distance: 20, transform: !0, scale_treshold: .1, rotation_treshold: 15, tap: !0, tap_double: !0, tap_max_interval: 300, tap_max_distance: 10, tap_double_distance: 20, hold: !0, hold_timeout: 500 }, Hammer.defaults || {}); b = L(e, b), function () { if (!b.css_hacks) return !1; for (var c = ["webkit", "moz", "ms", "o", ""], d = { userSelect: "none", touchCallout: "none", userDrag: "none", tapHighlightColor: "rgba(0,0,0,0)" }, e = "", f = 0; c.length > f; f++) for (var g in d) e = g, c[f] && (e = c[f] + e.substring(0, 1).toUpperCase() + e.substring(1)), a.style[e] = d[g] } (); var t, u, v, f = 0, g = 0, h = 0, i = {}, j = 0, k = !1, l = null, m = null, n = null, o = { x: 0, y: 0 }, p = null, q = null, r = {}, s = !1, w = "ontouchstart" in window, x = !1; this.option = function (a, d) { return d !== c && (b[a] = d), b[a] }, this.getDirectionFromAngle = function (a) { var c, d, b = { down: a >= 45 && 135 > a, left: a >= 135 || -135 >= a, up: -45 > a && a > -135, right: a >= -45 && 45 >= a }; for (d in b) if (b[d]) { c = d; break } return c }, this.destroy = function () { w ? O(a, "touchstart touchmove touchend touchcancel", I) : (O(a, "mouseup mousedown mousemove", I), O(a, "mouseout", J)) }; var H = { hold: function (a) { b.hold && (l = "hold", clearTimeout(q), q = setTimeout(function () { "hold" == l && E("hold", { originalEvent: a, position: i.start }) }, b.hold_timeout)) }, swipe: function (a) { if (i.move && "transform" !== l) { var c = i.move[0].x - i.start[0].x, e = i.move[0].y - i.start[0].y; f = Math.sqrt(c * c + e * e); var j = (new Date).getTime(), k = j - n; if (b.swipe && b.swipe_time > k && f > b.swipe_min_distance) { g = A(i.start[0], i.move[0]), h = d.getDirectionFromAngle(g), l = "swipe"; var m = { x: i.move[0].x - r.left, y: i.move[0].y - r.top }, o = { originalEvent: a, position: m, direction: h, distance: f, distanceX: c, distanceY: e, angle: g }; E("swipe", o) } } }, drag: function (a) { var c = i.move[0].x - i.start[0].x, e = i.move[0].y - i.start[0].y; if (f = Math.sqrt(c * c + e * e), b.drag && f > b.drag_min_distance || "drag" == l) { g = A(i.start[0], i.move[0]), h = d.getDirectionFromAngle(g); var j = "up" == h || "down" == h; if ((j && !b.drag_vertical || !j && !b.drag_horizontal) && f > b.drag_min_distance) return; l = "drag"; var m = { x: i.move[0].x - r.left, y: i.move[0].y - r.top }, n = { originalEvent: a, position: m, direction: h, distance: f, distanceX: c, distanceY: e, angle: g }; k && (E("dragstart", n), k = !1), E("drag", n), F(a) } }, transform: function (a) { if (b.transform) { var c = y(a); if (2 !== c) return !1; var d = D(i.start, i.move), e = C(i.start, i.move); if ("transform" === l || Math.abs(1 - e) > b.scale_treshold || Math.abs(d) > b.rotation_treshold) { l = "transform", i.center = { x: (i.move[0].x + i.move[1].x) / 2 - r.left, y: (i.move[0].y + i.move[1].y) / 2 - r.top }, k && (i.startCenter = i.center); var g = i.center.x - i.startCenter.x, h = i.center.y - i.startCenter.y; f = Math.sqrt(g * g + h * h); var j = { originalEvent: a, position: i.center, scale: e, rotation: d, distance: f, distanceX: g, distanceY: h }; return k && (E("transformstart", j), k = !1), E("transform", j), F(a), !0 } } return !1 }, tap: function (a) { var c = (new Date).getTime(), d = c - n; if (!b.hold || b.hold && b.hold_timeout > d) { var e = function () { if (o && b.tap_double && "tap" == m && i.start && b.tap_max_interval > n - p) { var a = Math.abs(o[0].x - i.start[0].x), c = Math.abs(o[0].y - i.start[0].y); return o && i.start && Math.max(a, c) < b.tap_double_distance } return !1 } (); if (e) l = "double_tap", p = null, E("doubletap", { originalEvent: a, position: i.start }), F(a); else { var g = i.move ? Math.abs(i.move[0].x - i.start[0].x) : 0, h = i.move ? Math.abs(i.move[0].y - i.start[0].y) : 0; f = Math.max(g, h), b.tap_max_distance > f && (l = "tap", p = c, o = i.start, b.tap && (E("tap", { originalEvent: a, position: i.start }), F(a))) } } } }; w ? N(a, "touchstart touchmove touchend touchcancel", I) : (N(a, "mouseup mousedown mousemove", I), N(a, "mouseout", J)) }