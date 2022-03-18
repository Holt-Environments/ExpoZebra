/**
 * ExpoZebra Intuiface Asset
 * Author: Anthony Mesa
 * Date: 03 18 2022
 * 
 * Designed for making API calls to the Expoleads Mobile Web API given a user's
 * badge_id retrieved from a successfull barcode scan.
 */

/**
 * ExpoZebra Intuiface Asset Prototype (class)
 * 
 * Inheritance on EventEmitter base class
 * @type {EventEmitter}
 */
ExpoZebra.prototype = new EventEmitter();
ExpoZebra.prototype.constructor = ExpoZebra;

/**
 * ExpoZebra constructor
 * @constructor
 */
function ExpoZebra() {
  var DeviceId = '';
  var Token = '';
  var BadgeId = '';

  Object.defineProperty(this, 'DeviceId', {
    get: function () { return DeviceId; },
    set: function (value) {
      if (DeviceId != value) {
        DeviceId = value;
        this.emit('DeviceIdChanged');
      }
    }
  });

  Object.defineProperty(this, 'Token', {
    get: function () { return Token; },
    set: function (value) {
      if (Token != value) {
        Token = value;
        this.emit('TokenChanged');
      }
    }
  });

  Object.defineProperty(this, 'BadgeId', {
    get: function () { return BadgeId; },
    set: function (value) {
      if (BadgeId != value) {
        BadgeId = value;
        this.emit('BadgeIdChanged');
      }
    }
  });

}