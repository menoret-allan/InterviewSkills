'use strict';

module.exports = (() => {

    function DNode(data, previous, next) {
        this.data = data || null;

        this.previous = previous;
        this.next = next;
    }

    DNode.prototype = {

        getData: function() {
            return this.data;
        },

        toString: function() {
            return String(this.data);
        }
    };

    return DNode;
})();
