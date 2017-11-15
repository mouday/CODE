# Module
# 1、不能被new
# 2、可以被include
# 3、module中的self.xx方法可以被直接调用
# 4、module中的普通方法，需要被某个class include之后，由对应的class调用

module Tool
    #这个方法无法直接运行
    def show_tip
        "this is the tip"
    end

    #这个方法可以通过Tool.say 来运行
    def self.say
        "hi"
    end
end

# puts Tool.say()