/**
* Created by Bruno Marchesson on 12/12/13.
*/

/**
* Inheritance on EventEmitter base class
* @type {EventEmitter}
*/
SimpleCounter.prototype = new EventEmitter();        // Here's where the inheritance occurs
SimpleCounter.prototype.constructor = SimpleCounter;

/**
* @constructor
*/
function SimpleCounter() {
    this.Count = 0;
}

/**
* Add one to the counter
*/
SimpleCounter.prototype.AddOne = function () {
    this.Count++;
    this.emit('CountChanged', [this.Count]);
};
/**
* Add the argument value to the counter
* @param increment the increment value
*/
SimpleCounter.prototype.Add = function (increment) {
    this.Count += increment;
    this.emit('CountChanged', [this.Count]);
};
/**
* Remove one to the counter
*/
SimpleCounter.prototype.SubstractOne = function () {
    this.Count--;
    this.emit('CountChanged', [this.Count]);
};
/**
* Remove the argument value to the counter
* @param increment the increment value
*/
SimpleCounter.prototype.Substract = function (increment) {
    this.Count -= increment;
    this.emit('CountChanged', [this.Count]);
};
/**
* Remove one to the counter
*/
SimpleCounter.prototype.Reset = function () {
    this.Count = 0;
    this.emit('CountChanged', [this.Count]);
};