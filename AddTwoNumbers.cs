using System;
using System.Security.Cryptography.X509Certificates;

 public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}

public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        bool AddOverflowFlag = false;

        ListNode Solution = new ListNode((l1.val + l2.val)%10);

        AddOverflowFlag = l1.val + l2.val >= 10;

        Solution.next = AddNextDigit(l1.next, l2.next, AddOverflowFlag);

        return Solution;
    }

    public ListNode AddNextDigit(ListNode l1, ListNode l2, bool AddOverflowFlag)
    {
        if(l1 == null && l2 == null && !AddOverflowFlag){
            return null;
        }

        //Adding L1, L2 and AddOverflow, with the assumtion that null is 0
        ListNode Solution = new ListNode(((l1 == null? 0 : l1.val) + (l2 == null? 0 : l2.val) + (AddOverflowFlag? 1 : 0))%10);

        //Marking if the Sum of L1, L2 and AddOverflow is 10 or more
        AddOverflowFlag = (l1 == null? 0 : l1.val) + (l2 == null? 0 : l2.val) + (AddOverflowFlag? 1 : 0) >= 10;

         Solution.next = AddNextDigit(l1 == null? null : l1.next, l2 == null? null : l2.next, AddOverflowFlag);

        return Solution;
    }
}

