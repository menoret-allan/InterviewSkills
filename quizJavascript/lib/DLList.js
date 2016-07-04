'use strict';

const DNode = require('./DNode.js');

module.exports = (() => {

    let head, tail, size;

    function DLList(data) {
        _initDDList();

        if (null != data && data.length != 0) {
            data.forEach(ite => this.addLast(ite));
        }
    }

    function _initDDList() {
        head = new DNode();
        tail = new DNode();

        size = 0;

        head.next = tail;
        tail.previous = head;
    }

    function _addBefore(referenceNode, element) {
        const prevNode = _getPrev(referenceNode);
        const newNode = new DNode(element, prevNode, referenceNode);

        referenceNode.previous = newNode;
        prevNode.next = newNode;

        size++;
    }

    function _addAfter(referenceNode, element) {
        const nextNode = _getNext(referenceNode);
        const newNode = new DNode(element, referenceNode, nextNode);

        referenceNode.next = newNode;
        nextNode.previous = newNode;

        size++;
    }

    function _getNext(referenceNode) {
        if (referenceNode == tail)
            throw new Error("Reference node cannot be equal to the tail");

        return referenceNode.next;
    }

    function _getPrev(referenceNode) {
        if (referenceNode == head)
            throw new Error("Reference node cannot be equal to the head");

        return referenceNode.previous;
    }

    function _remove(removeNode) {
        const prevNode = _getPrev(removeNode);
        const nextNode = _getNext(removeNode);

        removeNode.previous = null;
        removeNode.next = null;

        prevNode.next = nextNode;
        nextNode.previous = prevNode;

        size--;

        return removeNode.getData();
    }

    function _removeCheckEmptyList() {
        if (this.isEmpty())
            throw new Error("Double Linked list is empty, cannot remove element");
    }

    DLList.prototype = {
        isEmpty() {
            return (size === 0);
        },

        getSize() {
            return size;
        },

        clear() {
            head = null;
            tail = null;

            size = 0;
        },

        addFirst(element) {
            _addAfter(head, element);
        },

        addLast(element) {
            _addBefore(tail, element);
        },

        removeLast() {
            _removeCheckEmptyList.call(this);

            return _remove(_getPrev(tail));
        },

        removeFirst() {
            _removeCheckEmptyList.call(this);

            return _remove(_getNext(head));
        },

        toString() {
            let strTabs = [];

            if (null != head) {
                let probe = head.next;

                while (probe != tail) {
                    strTabs.push(probe.toString());
                    probe = probe.next;
                }
            }

            return "[" + strTabs.join(" ") + "]";
        }
    };

    return DLList;
})();
