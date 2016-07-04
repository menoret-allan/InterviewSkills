const DLList = require('../lib/DLList.js');

describe("Test algo / js : ", () => {

    let dllist;

    beforeEach(() => {
        dllist = new DLList(["B", "C", "D", "E"]);
    });

    it("Check stringify list's result", () => {

        expect(dllist.toString()).toBe("[B C D E]");

        dllist.clear();

        expect(dllist.getSize()).toBe(0);

        expect(dllist.toString()).toBe("[]");
    })

    it("Check the list's getSize()", () => {

        expect(dllist.getSize()).toBe(4);

        dllist.clear();

        expect(dllist.getSize()).toBe(0);
    })

    it("Check the list's contents", () => {

        expect(dllist.isEmpty()).toBe(false);

        dllist.clear();

        expect(dllist.isEmpty()).toBe(true);
    })

    it("Add an element on the DDList", () => {

        dllist.addFirst("A");
        expect(dllist.toString()).toEqual("[A B C D E]");
        expect(dllist.getSize()).toEqual(5);

        dllist.addLast("F");
        expect(dllist.toString()).toEqual("[A B C D E F]");
        expect(dllist.getSize()).toEqual(6);
    })

    it("Remove an element on an empty list", () => {

        dllist.clear()

        expect(() => {dllist.removeLast()}).toThrow();
    });

    it("Remove an element on the DDList", () => {

        expect(dllist.removeFirst()).toEqual("B");
        expect("E", dllist.removeLast());

        expect(2, dllist.getSize());

        expect("C", dllist.removeFirst());
        expect("D", dllist.removeLast());

        expect(0, dllist.getSize());
    });

});
