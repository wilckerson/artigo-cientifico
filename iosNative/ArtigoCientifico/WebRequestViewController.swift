//
//  WebRequestViewController.swift
//  ArtigoCientifico
//
//  Created by Wilckerson Ganda on 08/04/16.
//  Copyright © 2016 Wilckerson Ganda. All rights reserved.
//

import UIKit

class WebRequestViewController: UIViewController {
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    @IBAction func onClickBtn(sender: UIButton) {
        lblElapsedTime.text = "Requesting...";
        let startTime = NSDate();
        
        
        let url = NSURL(string: "https://api.github.com/users/xamarin/repos");
        
        let task = NSURLSession.sharedSession().dataTaskWithURL(url!, completionHandler: { (data, response,error) -> Void in
            
            let finishTime = NSDate();
            let executionTime = finishTime.timeIntervalSinceDate(startTime) * 1000;
            
            NSLog("executionTime = %0.5f", executionTime);
            dispatch_async(dispatch_get_main_queue(), {
                //perform all UI stuff here
                self.lblElapsedTime.text = String(format: "ElapsedTime: %.3f ms", executionTime);
            })
            
            
            let resultString = NSString(data: data!, encoding: NSUTF8StringEncoding);
            print(resultString);
        })
        
        task.resume()
    }
    
    @IBOutlet weak var lblElapsedTime: UILabel!
}
