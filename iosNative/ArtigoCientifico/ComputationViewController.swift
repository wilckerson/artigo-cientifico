//
//  WebRequestViewController.swift
//  ArtigoCientifico
//
//  Created by Wilckerson Ganda on 08/04/16.
//  Copyright © 2016 Wilckerson Ganda. All rights reserved.
//

import UIKit

class ComputationViewController: UIViewController {
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    @IBOutlet weak var lblElapsedTime: UILabel!
    
    @IBOutlet weak var lblResult: UILabel!
    @IBAction func onClickBtn(sender: UIButton) {
        lblElapsedTime.text = "Requesting...";
        let startTime = NSDate();
        
        //Algorithm
        let result = computePiSpigotAlgorithm(1000);
        
        let finishTime = NSDate();
        let executionTime = finishTime.timeIntervalSinceDate(startTime);
        
        NSLog("executionTime = %0.5f", executionTime);
        //dispatch_async(dispatch_get_main_queue(), {
        //perform all UI stuff here
        self.lblElapsedTime.text = String(format: "ElapsedTime: %0.5f ms", executionTime);
        self.lblResult.text = result;
        //})
    }
    
    func computePiSpigotAlgorithm(digits:Int) -> String{
        
        var zero = [String]();
        zero.append("0");
        zero.append("00");
        zero.append("000");
        
        let pi :NSMutableString = NSMutableString(capacity:digits);
        var d:Int = 0;
        var e, b, g, r : Int;
        var c = (digits / 4 + 1) * 14;
        var a = [Int](count: c, repeatedValue: 20000000);
        let f: Int = 10000;
        
        c -= 14;
        b = c;
        while (b > 0)
        {
            e = d % f;
            d = e;
            
            b -= 1;
            while (b > 0)
            {
                d = d * b + a[b];
                g = (b << 1) - 1;
                a[b] = (d % g) * f;
                d /= g;
                
                b -= 1;
            }
            
            r = e + d / f;
            
            if (r < 1000)
            {
                pi.appendString(zero[r > 99 ? 0 : r > 9 ? 1 : 2]);
            }
            pi.appendString(r.description);
            c -= 14;
            b = c;
        }
        return pi.description;
        
        
    }
    
}
